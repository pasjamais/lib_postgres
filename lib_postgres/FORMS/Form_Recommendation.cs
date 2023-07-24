using lib_postgres.PARTIAL;
using lib_postgres.VISUAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static lib_postgres.FORMS.Form_Recommendation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lib_postgres.FORMS
{
    public partial class Form_Recommendation : Form
    {
        public class Recomendation_2
        {
            public long artToRead_DB_Id { get; set; }
            public DateOnly? artToRead_DB_Date { get; set; }
            public long? artToRead_DB_SourceArtId { get; set; }
            public long? artToRead_DB_SourceAuthorId { get; set; }
            public long? artToRead_DB_SourceAnotherId { get; set; }
            public long? artToRead_DB_ToreadArtId { get; set; }
            public long? artToRead_DB_ToreadAuthorId { get; set; }
            public string? artToRead_DB_Comment { get; set; }
            public bool? artToRead_DB_IsDeleted { get; set; }


            public string? Art_Source_Text;
            public string? Author_Source_Text;
            public string? SourceAnother_Text;
            public string? Art_ToRead_Text;
            public string? Author_ToRead_Text;

            public Recomendation_2(ArtToRead artToRead,
                                string? art_Source_Text,
                                string? author_Source_Text,
                                string? sourceAnother_Text,
                                string? art_ToRead_Text,
                                string? author_ToRead_Text) : this(art_Source_Text,
                                                                    author_Source_Text,
                                                                    sourceAnother_Text,
                                                                    art_ToRead_Text,
                                                                    author_ToRead_Text)
            {
                artToRead_DB_Id = artToRead.Id;
                artToRead_DB_Date = artToRead.Date;
                artToRead_DB_SourceArtId = artToRead.SourceArtId;
                artToRead_DB_SourceAuthorId = artToRead.SourceAuthorId;
                artToRead_DB_SourceAnotherId = artToRead.SourceAuthorId;
                artToRead_DB_ToreadArtId = artToRead.ToreadAuthorId;
                artToRead_DB_ToreadAuthorId = artToRead.ToreadAuthorId;
                artToRead_DB_Comment = artToRead.Comment;
                artToRead_DB_IsDeleted = artToRead.IsDeleted;
            }
            public Recomendation_2(
                               string? art_Source_Text,
                               string? author_Source_Text,
                               string? sourceAnother_Text,
                               string? art_ToRead_Text,
                               string? author_ToRead_Text)
            {
                Art_Source_Text = art_Source_Text;
                Author_Source_Text = author_Source_Text;
                SourceAnother_Text = sourceAnother_Text;
                Art_ToRead_Text = art_ToRead_Text;
                Author_ToRead_Text = author_ToRead_Text;
            }
        }
        public class Recomendation_old
        {
            public ArtToRead artToRead_DB;
            public string? Art_Source_Text;
            public string? Author_Source_Text;
            public string? SourceAnother_Text;
            public string? Art_ToRead_Text;
            public string? Author_ToRead_Text;

            public Recomendation_old(ArtToRead artToRead,
                                string? art_Source_Text,
                                string? author_Source_Text,
                                string? sourceAnother_Text,
                                string? art_ToRead_Text,
                                string? author_ToRead_Text)
            {
                artToRead_DB = artToRead;
                Art_Source_Text = art_Source_Text;
                Author_Source_Text = author_Source_Text;
                SourceAnother_Text = sourceAnother_Text;
                Art_ToRead_Text = art_ToRead_Text;
                Author_ToRead_Text = author_ToRead_Text;
            }
        }

        public Form_Recommendation() 
        {
            InitializeComponent();
            treeView_preparation();

            var first_level_node = Graph_Agent.Get_First_Node_by_Text(treeView.Nodes, Graph_Agent.caption_from_books);
            Graph_Agent.Get_Recomendations_from_Arts(first_level_node.Nodes);
            first_level_node.Expand();

            first_level_node = Graph_Agent.Get_First_Node_by_Text(treeView.Nodes, Graph_Agent.caption_from_authors);
            Graph_Agent.get_recomendations_from_authors(first_level_node.Nodes);
            first_level_node.Expand();

            first_level_node = Graph_Agent.Get_First_Node_by_Text(treeView.Nodes, Graph_Agent.caption_from_anothers);
            Graph_Agent.get_recomendations_from_anothers(first_level_node.Nodes);
            first_level_node.Expand();
        }
  
        public void treeView_preparation()
        {
            treeView.Nodes.Add(new TreeNode(Graph_Agent.caption_from_books));
            treeView.Nodes.Add(new TreeNode(Graph_Agent.caption_from_authors));
            treeView.Nodes.Add(new TreeNode(Graph_Agent.caption_from_anothers));
        }

        private void bt_show_art_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            Graph_Agent.Get_Recomendations_from_Arts(treeView.Nodes);     
        }

        private void bt_show_another_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            Graph_Agent.get_recomendations_from_anothers(treeView.Nodes);
        }

        private void bt_show_authors_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            Graph_Agent.get_recomendations_from_authors(treeView.Nodes);
        }
    }
}
