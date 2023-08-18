using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VISUAL.TreeViewViz
{
    public class Graph_Agent
    {
        public const string caption_from_books = "Из книг";
        public const string caption_from_authors = "От авторов";
        public const string caption_from_anothers = "Другое";
        public struct Element
        {
            public long? number;
            public string label;
            public Element(long? number, string label)
            {
                this.number = number;
                this.label = label;
            }
        }
        public struct Relation
        {
            public long? number_parent;
            public long? number;
            public Relation(long? number_parent, long? number)
            {
                this.number_parent = number_parent;
                this.number = number;
            }
        }
        public static TreeNode? Get_First_Node_by_Text(TreeNodeCollection nodes, string text_to_find)
        {
            return nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text.Equals(text_to_find));
        }

        private static TreeNode? Get_First_Node_by_Tag(TreeNodeCollection nodes, object object_to_find)
        {
            return nodes.OfType<TreeNode>().FirstOrDefault(node => node.Tag.Equals(object_to_find));
        }

        private static T ConvertFromDBVal<T>(object obj)
        //for error: Unable to cast object of type 'System.DBNull' to type 'System.String`
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default; // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
         public static List<Recomendation> Get_Recommendations()
        {
            var rec = CODE.Queries_SQL_Direct.Fill_DataTable_by_Query(DB_Agent.Get_Query(3).Text);
            List<Recomendation> data = new List<Recomendation>();
            data = (from DataRow row in rec.Rows
                    select new Recomendation
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



        #region from arts
        /// <summary>
        /// for DataTreeView
        /// </summary>
        /// <param name="nodes"></param>
        public static void Get_Recommendations_for_Arts(TreeNodeCollection nodes)
        {
            List<Recomendation> recomendatons = Get_Recommendations();
            List<Node_Simple_Element> arts_sources = Get_Source_Arts(recomendatons);

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

            List<Node_Simple_Element> arts_recommended = Get_Recommended_Arts_for_Arts(arts_sources, recomendatons);
            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = Get_First_Node_by_Tag(nodes, s.Id_Parent);
                var second_level_node = Get_First_Node_by_Text(first_level_node.Nodes, "Книги");
                second_level_node.Nodes.Add(node);
            }

            List<Node_Simple_Element> authors_recommended = Get_Recommended_Authors_for_Arts(arts_sources, recomendatons);
            foreach (var s in authors_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = Get_First_Node_by_Tag(nodes, s.Id_Parent);
                var second_level_node = Get_First_Node_by_Text(first_level_node.Nodes, "Авторы");
                second_level_node.Nodes.Add(node);
            }
        }
    

        public static List<Node_Simple_Element> Get_Source_Arts(List<Recomendation> recomendatons)
        {
            var arts_sources_ids = (from rec in recomendatons
                                    where rec.SourceArtId != null
                                    select rec.SourceArtId)
                                                       .Distinct().ToList();
            var arts_authors = CODE.Queries_LinQ.Get_Arts();
            List<Node_Simple_Element> arts_sources =

               (from art_source_id in arts_sources_ids
                join rec in arts_authors on art_source_id equals rec.Id
                select new Node_Simple_Element(art_source_id, rec.Authors + " — " + rec.Name )).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_sources;
        }
        public static List<Node_Simple_Element> Get_Source_Arts()
        {
            return Get_Source_Arts(Get_Recommendations());
        }

        public static List<Node_Simple_Element> Get_Recommended_Arts_for_Arts(List<Node_Simple_Element> arts_sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source_art in arts_sources
                                    join rec in recomendatons
                                    on source_art.Id equals rec.SourceArtId
                                    where rec.ToreadArtId is not null
                                    select new Node_Simple_Element(
                                        rec.ToreadArtId,
                                        rec.Art_ToRead_Text, source_art.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        public static List<Node_Simple_Element> Get_Recommended_Arts_for_Arts()
        {
            return Get_Recommended_Arts_for_Arts(Get_Source_Arts(), Get_Recommendations());
        }
        public static List<Node_Simple_Element> Get_Recommended_Authors_for_Arts(List<Node_Simple_Element> arts_sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source_art in arts_sources
                                    join rec in recomendatons
                                    on source_art.Id equals rec.SourceArtId
                                    where rec.ToreadAuthorId is not null
                                    select new Node_Simple_Element(
                                        rec.ToreadAuthorId,
                                        rec.Author_ToRead_Text, source_art.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        public static List<Node_Simple_Element> Get_Recommended_Authors_for_Arts()
        {
            return Get_Recommended_Authors_for_Arts(Get_Source_Arts(), Get_Recommendations());
        }
        #endregion

        #region from authors
        /// <summary>
        ///  for DataTreeView
        /// </summary>
        /// <param name="nodes"></param>
        public static void Get_Recommendations_for_Authors(TreeNodeCollection nodes)
        {
            List<Recomendation> recomendatons = Get_Recommendations();
            List<Node_Simple_Element> sources = Get_Source_Authors(recomendatons);

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
            List<Node_Simple_Element> arts_recommended = Get_Recommended_Arts_for_Authors(sources, recomendatons);

            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Parent));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Книги"));
                second_level_node.Nodes.Add(node);
            }
            List<Node_Simple_Element> authors_recommended = Get_Recommended_Authors_for_Authors(sources, recomendatons);
            foreach (var s in authors_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Parent));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Авторы"));
                second_level_node.Nodes.Add(node);
            }
        }

        public static List<Node_Simple_Element> Get_Source_Authors(List<Recomendation> recomendatons)
        {
            var authors_sources_ids = (from rec in recomendatons
                                       where rec.SourceAuthorId != null
                                       select rec.SourceAuthorId)
                                                       .Distinct().ToList();
            var authors = DB_Agent.Get_Authors();
            List<Node_Simple_Element> authors_sources =

               (from source_id in authors_sources_ids
                join rec in authors on source_id equals rec.Id
                select new Node_Simple_Element(source_id, rec.Name)).OrderBy(simple_element => simple_element.Text).ToList();
            return authors_sources;
        }
        public static List<Node_Simple_Element> Get_Source_Authors()
        {
           return Get_Source_Authors(Get_Recommendations());
        }
        public static List<Node_Simple_Element> Get_Recommended_Arts_for_Authors(List<Node_Simple_Element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAuthorId
                                    where rec.ToreadArtId is not null
                                    select new Node_Simple_Element(
                                        rec.ToreadArtId,
                                        rec.Art_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        public static List<Node_Simple_Element> Get_Recommended_Arts_for_Authors()
        {
            return Get_Recommended_Arts_for_Authors(Get_Source_Authors(), Get_Recommendations());
        }
        public static List<Node_Simple_Element> Get_Recommended_Authors_for_Authors(List<Node_Simple_Element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAuthorId
                                    where rec.ToreadAuthorId is not null
                                    select new Node_Simple_Element(
                                        rec.ToreadAuthorId,
                                        rec.Author_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        public static List<Node_Simple_Element> Get_Recommended_Authors_for_Authors()
        {
            return Get_Recommended_Authors_for_Authors(Get_Source_Authors(), Get_Recommendations());
        }
        #endregion

        #region from another
        /// <summary>
        ///  for Graphviz
        /// </summary>
        /// <param name="nodes"></param>
        public static void Get_Recommendations_for_Anothers(TreeNodeCollection nodes)
        {
            List<Recomendation> recomendatons = Get_Recommendations();
            List<Node_Simple_Element> sources = Get_Another_Sources(recomendatons);

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
            List<Node_Simple_Element> arts_recommended = Get_Recommended_Arts_for_Anothers(sources, recomendatons);

            foreach (var s in arts_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Parent));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Книги"));
                second_level_node.Nodes.Add(node);
            }
            List<Node_Simple_Element> authors_recommended = Get_Recommended_Authors_for_Anothers(sources, recomendatons);
            foreach (var s in authors_recommended)
            {
                TreeNode node = new TreeNode(s.Text);
                node.Tag = s.Id;
                var first_level_node = nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Tag.Equals(s.Id_Parent));
                var second_level_node = first_level_node.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals("Авторы"));
                second_level_node.Nodes.Add(node);
            }
        }

        public static List<Node_Simple_Element> Get_Another_Sources(List<Recomendation> recomendatons)
        {
            var authors_sources_ids = (from rec in recomendatons
                                       where rec.SourceAnotherId != null
                                       select rec.SourceAnotherId)
                                                       .Distinct().ToList();
            var anothers = DB_Agent.Get_Another_Sources();
            List<Node_Simple_Element> authors_sources =

               (from source_id in authors_sources_ids
                join rec in anothers on source_id equals rec.Id
                select new Node_Simple_Element(source_id, rec.Name)).OrderBy(simple_element => simple_element.Text).ToList();
            return authors_sources;
        }

        public static List<Node_Simple_Element> Get_Another_Sources()
        {
            return Get_Another_Sources(Get_Recommendations());
        }

        public static List<Node_Simple_Element> Get_Recommended_Arts_for_Anothers(List<Node_Simple_Element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAnotherId // существенно
                                    where rec.ToreadArtId is not null
                                    select new Node_Simple_Element(
                                        rec.ToreadArtId,
                                        rec.Art_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        public static List<Node_Simple_Element> Get_Recommended_Arts_for_Anothers()
        { 
            return Get_Recommended_Arts_for_Anothers(Get_Another_Sources(),Get_Recommendations());
        }
        public static List<Node_Simple_Element> Get_Recommended_Authors_for_Anothers(List<Node_Simple_Element> sources, List<Recomendation> recomendatons)
        {
            var arts_recommended = (from source in sources
                                    join rec in recomendatons
                                    on source.Id equals rec.SourceAnotherId // существенно
                                    where rec.ToreadAuthorId is not null
                                    select new Node_Simple_Element(
                                        rec.ToreadAuthorId,
                                        rec.Author_ToRead_Text, source.Id)
                                   ).OrderBy(simple_element => simple_element.Text).ToList();
            return arts_recommended;
        }
        public static List<Node_Simple_Element> Get_Recommended_Authors_for_Anothers()
        {
            return Get_Recommended_Authors_for_Anothers(Get_Another_Sources(), Get_Recommendations());
        }
        #endregion

    }
}
