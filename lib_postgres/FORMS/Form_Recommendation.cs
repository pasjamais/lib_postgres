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
        public const string caption_from_books = "Из книг";
        public const string caption_from_authors = "От авторов";
        public const string caption_from_anothers = "Другое";
  
        public class Simple_tree_element
        {
            public long? Id_Father;
            public long? Id;
            public string? Text;
            public Simple_tree_element(long? id, string? text)
            {
                Id = id;
                Text = text;
            }

            public Simple_tree_element(long? id, string? text, long? id_father) : this(id, text)
            {
                Id_Father = id_father;
            }
        }

        public class Recomendation
        {
            public long Id { get; set; }
            public DateOnly? Date { get; set; }
            public long? SourceArtId { get; set; }
            public long? SourceAuthorId { get; set; }
            public long? SourceAnotherId { get; set; }
            public long? ToreadArtId { get; set; }
            public long? ToreadAuthorId { get; set; }
            public string? Comment { get; set; }
            public bool? IsDeleted { get; set; }

            public string? Art_Source_Text;
            public string? Author_Source_Text;
            public string? SourceAnother_Text;
            public string? Art_ToRead_Text;
            public string? Author_ToRead_Text;


        }
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

            var first_level_node = treeView.Nodes.OfType<TreeNode>()
                           .FirstOrDefault(node => node.Text.Equals(caption_from_books));
            get_recomendations_from_arts(first_level_node.Nodes);
            first_level_node.Expand();



            first_level_node = treeView.Nodes.OfType<TreeNode>()
                          .FirstOrDefault(node => node.Text.Equals(caption_from_authors));
              get_recomendations_from_authors(first_level_node.Nodes);
            first_level_node.Expand();


            first_level_node = treeView.Nodes.OfType<TreeNode>()
                          .FirstOrDefault(node => node.Text.Equals(caption_from_anothers));
              get_recomendations_from_anothers(first_level_node.Nodes);
            first_level_node.Expand();

        }


        public void treeView_preparation()
        {
            treeView.Nodes.Add(new TreeNode(caption_from_books));
            treeView.Nodes.Add(new TreeNode(caption_from_authors));
            treeView.Nodes.Add(new TreeNode(caption_from_anothers));
        }

        #region from authors
        public void get_recomendations_from_authors(TreeNodeCollection nodes)
        {
            List<Recomendation> recomendatons = Get_Recomendations();
            List<Simple_tree_element> sources = Get_Sources_Authors(recomendatons);
            
            foreach (var s in sources)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                nodes.Add(node);
                TreeNode node_books = new TreeNode("Книги");
                node.Nodes.Add(node_books);
                TreeNode node_authors = new TreeNode("Авторы");
                node.Nodes.Add(node_authors);
            }
            List<Simple_tree_element> arts_recommended = get_arts_from_authors(sources, recomendatons);

            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Father));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Книги"));
                second_level_node.Nodes.Add(node);
            }
            List<Simple_tree_element> authors_recommended = get_authors_from_authors(sources, recomendatons);
            foreach (var s in authors_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Father));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Авторы"));
                second_level_node.Nodes.Add(node);
            }
        }

        public List<Simple_tree_element> Get_Sources_Authors(List<Recomendation> recomendatons)
        {
            var authors_sources_ids = (from rec in recomendatons
                                       where rec.SourceAuthorId != null
                                       select rec.SourceAuthorId)
                                                       .Distinct().ToList();
            var authors = DB_Agent.Get_Authors();
            List<Simple_tree_element> authors_sources =

               (from source_id in authors_sources_ids
                join rec in authors on source_id equals rec.Id
                select new Simple_tree_element(source_id, rec.Name)).OrderBy(simple_element => simple_element.Text).ToList();
            return authors_sources;
        }

        public List<Simple_tree_element> get_arts_from_authors(List<Simple_tree_element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAuthorId
                                    where rec.ToreadArtId is not null
                                    select new Simple_tree_element(
                                        rec.ToreadArtId,
                                        rec.Art_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }

        public List<Simple_tree_element> get_authors_from_authors(List<Simple_tree_element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAuthorId
                                    where rec.ToreadAuthorId is not null
                                    select new Simple_tree_element(
                                        rec.ToreadAuthorId,
                                        rec.Author_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        #endregion


        #region from arts


        public void get_recomendations_from_arts(TreeNodeCollection nodes)
        {
            List<Recomendation> recomendatons = Get_Recomendations();
            List<Simple_tree_element> arts_sources = Get_Sources_Arts(recomendatons);
            List<Simple_tree_element> arts_recommended = Get_Recommended_Arts(arts_sources, recomendatons);

            foreach (var s in arts_sources)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                nodes.Add(node);
                TreeNode node_books = new TreeNode("Книги");
                node.Nodes.Add(node_books);
                TreeNode node_authors = new TreeNode("Авторы");
                node.Nodes.Add(node_authors);

            }
            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Father));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Книги"));
                second_level_node.Nodes.Add(node);
            }

            List<Simple_tree_element> authors_recommended = Get_Recommended_Authors(arts_sources, recomendatons);
            foreach (var s in authors_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Father));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Авторы"));
                second_level_node.Nodes.Add(node);
            }
        }

        public List<Simple_tree_element> Get_Sources_Arts(List<Recomendation> recomendatons)
        {
            var arts_sources_ids = (from rec in recomendatons
                                    where rec.SourceArtId != null
                                    select rec.SourceArtId)
                                                       .Distinct().ToList();
            var arts_authors = CODE.Queries_LinQ.Get_Arts();
            List<Simple_tree_element> arts_sources =

               (from art_source_id in arts_sources_ids
                join rec in arts_authors on art_source_id equals rec.Id
                select new Simple_tree_element(art_source_id, rec.Name)).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_sources;
        }

        public List<Simple_tree_element> Get_Recommended_Arts(List<Simple_tree_element> arts_sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source_art in arts_sources
                                    join rec in recomendatons
                                    on source_art.Id equals rec.SourceArtId
                                    where rec.ToreadArtId is not null
                                    select new Simple_tree_element(
                                        rec.ToreadArtId,
                                        rec.Art_ToRead_Text, source_art.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }

        public List<Simple_tree_element> Get_Recommended_Authors(List<Simple_tree_element> arts_sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source_art in arts_sources
                                    join rec in recomendatons
                                    on source_art.Id equals rec.SourceArtId
                                    where rec.ToreadAuthorId is not null
                                    select new Simple_tree_element(
                                        rec.ToreadAuthorId,
                                        rec.Author_ToRead_Text, source_art.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        #endregion

        #region from another
        public void get_recomendations_from_anothers(TreeNodeCollection nodes)
        {
            List<Recomendation> recomendatons = Get_Recomendations();
            List<Simple_tree_element> sources = Get_Another_Sources(recomendatons);

            foreach (var s in sources)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                nodes.Add(node);
                TreeNode node_books = new TreeNode("Книги");
                node.Nodes.Add(node_books);
                TreeNode node_authors = new TreeNode("Авторы");
                node.Nodes.Add(node_authors);
            }
            List<Simple_tree_element> arts_recommended = get_arts_from_anothers(sources, recomendatons);

            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Father));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Книги"));
                second_level_node.Nodes.Add(node);
            }
            List<Simple_tree_element> authors_recommended = get_authors_from_anothers(sources, recomendatons);
            foreach (var s in authors_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Father));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Авторы"));
                second_level_node.Nodes.Add(node);
            }
        }

        public List<Simple_tree_element> Get_Another_Sources(List<Recomendation> recomendatons)
        {
            var authors_sources_ids = (from rec in recomendatons
                                       where rec.SourceAnotherId != null
                                       select rec.SourceAnotherId)
                                                       .Distinct().ToList();
            var anothers = DB_Agent.Get_Another_Sources();
            List<Simple_tree_element> authors_sources =

               (from source_id in authors_sources_ids
                join rec in anothers on source_id equals rec.Id
                select new Simple_tree_element(source_id, rec.Name)).OrderBy(simple_element => simple_element.Text).ToList();
            return authors_sources;
        }

        public List<Simple_tree_element> get_arts_from_anothers(List<Simple_tree_element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAnotherId // существенно
                                    where rec.ToreadArtId is not null
                                    select new Simple_tree_element(
                                        rec.ToreadArtId,
                                        rec.Art_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }

        public List<Simple_tree_element> get_authors_from_anothers(List<Simple_tree_element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAnotherId // существенно
                                    where rec.ToreadAuthorId is not null
                                    select new Simple_tree_element(
                                        rec.ToreadAuthorId,
                                        rec.Author_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }

        #endregion





        public List<Recomendation> Get_Recomendations()
        {
            var rec = CODE.Queries_SQL_Direct.Fill_DataTable_by_Query(DB_Agent.Get_Query(3).Text);
            List<Recomendation> data = new List<Recomendation>();

            data = (from DataRow row in rec.Rows
                    select (Recomendation)new Recomendation
                    {
                        Art_Source_Text = row["Art_Source_Text"].ToString(),
                        Author_Source_Text = row["Author_Source_Text"].ToString(),
                        SourceAnother_Text = row["SourceAnother_Text"].ToString(),
                        Art_ToRead_Text = row["Art_ToRead_Text"].ToString(),
                        Author_ToRead_Text = row["Author_ToRead_Text"].ToString(),
                        Id = (long)row["Id"],
                        //                     Date = (DateOnly?)row["Date"],
                        SourceArtId = ConvertFromDBVal<long?>(row["source_art_id"]),

                        SourceAuthorId = ConvertFromDBVal<long?>(row["Source_Author_Id"]),
                        SourceAnotherId = ConvertFromDBVal<long?>(row["Source_Another_Id"]),
                        ToreadArtId = ConvertFromDBVal<long?>(row["Toread_Art_Id"]),
                        ToreadAuthorId = ConvertFromDBVal<long?>(row["Toread_Author_Id"]),
                        Comment = (string)row["Comment"],
                        IsDeleted = ConvertFromDBVal<bool?>(row["_Is_Deleted"]),
                    }).ToList();
            return data;
        }



        public static T ConvertFromDBVal<T>(object obj)
        //for error: Unable to cast object of type 'System.DBNull' to type 'System.String`
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }



        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }



        private void bt_show_art_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            get_recomendations_from_arts(treeView.Nodes);
            
            
        }

        private void bt_show_another_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            get_recomendations_from_anothers(treeView.Nodes);
        }

        private void bt_show_authors_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            get_recomendations_from_authors(treeView.Nodes);
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
