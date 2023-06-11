using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lib_postgres.FORMS
{
    public partial class Form_Recommendation : Form
    {
        public class art_adoptee
        {
            public long Id;
            public DateOnly? Date;
            public long? Art_Source_Id;
            public string? Art_Source_Text;
            public long? Art_ToRead_Id;
            public string? Art_ToRead_Text;
            public string? Comment;

            public art_adoptee(long id,
                DateOnly? date,
                long? art_Source_Id,
                string? art_Source_text,
                long? art_ToRead_id,
                string? art_ToRead_text,
                string? comment)
            {
                Id = id;
                Date = date;
                Art_Source_Id = art_Source_Id;
                Art_Source_Text = art_Source_text;
                Art_ToRead_Id = art_ToRead_id;
                Art_ToRead_Text = art_ToRead_text;
                Comment = comment;

            }
        }


        public void get_art_to_art_nodes (TreeNodeCollection nodes)
        {
            var arts_authors = CODE.Queries_LinQ.Get_Arts();
            var recs = DB_Agent.Get_Recommendations();
            var temp = (from rec in recs
                        join art_source in arts_authors
                            on rec.SourceArtId equals art_source.Id
                        select new
                        {
                            Id = rec.Id,
                            Date = rec.Date,
                            Art_Source_Id = rec.SourceArtId,
                            Art_Source_Text = art_source.Name + " | " + art_source.Authors,
                            Comment = rec.Comment,
                            Art_ToRead_Id = rec.ToreadArtId
                        }).ToList();
            arts_authors = CODE.Queries_LinQ.Get_Arts();
            List<art_adoptee> sad = (from tem in temp
                                     join art_toread in arts_authors
                                       on tem.Art_ToRead_Id equals art_toread.Id
                                     select new
                                         art_adoptee(tem.Id,
                                                       tem.Date,
                                                       tem.Art_Source_Id,
                                                       tem.Art_Source_Text,
                                                       tem.Art_ToRead_Id,
                                                       art_toread.Name + " | " + art_toread.Authors,
                                                       tem.Comment)
             ).ToList();
            var arts_sources = (from std in sad
                                select std)
               .Select(std => new { std.Art_Source_Id, std.Art_Source_Text })
               .Distinct().OrderBy(n => n.Art_Source_Text).ToList();
            var arts_recommended = (from source_art in arts_sources
                                    join rec in sad
                                    on source_art.Art_Source_Id equals rec.Art_Source_Id
                                    select new
                                    {
                                        source_art.Art_Source_Id,
                                        rec.Art_ToRead_Id,
                                        rec.Art_ToRead_Text
                                    }).ToList();
            foreach (var s in arts_sources)
            {
                TreeNode node = new TreeNode(s.Art_Source_Text);
                node.Tag = s.Art_Source_Id;
                nodes.Add(node);
            }
            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Art_ToRead_Text);
                node.Tag = s.Art_ToRead_Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Art_Source_Id));
                first_level_node.Nodes.Add(node);
            }
        }

        public Form_Recommendation()
        {
            InitializeComponent();
            get_art_to_art_nodes(treeView.Nodes);


        }


    }
}
