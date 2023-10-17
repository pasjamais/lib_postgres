using lib_postgres.QUERIES;
using lib_postgres.VIEW.COMBOBOX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lib_postgres.VIEW.SPEC_ENTITIES_VIEWS
{
    public class Structures
    {
        public struct Short_Book
        {
            public long? Id { get; set; }
            public string Name { get; set; }
            public Short_Book(long id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        public struct Short_Art : IShow_in_Combobox

        {
            public long? Id { get; set; }
            public string Name { get; set; }
            public Short_Art(long id, string name)
            {
                Id = id;
                Name = name;
            }
            public static void Show_in_Combobox(ComboBox CB)
            {
                var elements = Queries_LinQ.Get_Short_Arts();
                long id = 0;
                if (elements != null && elements.Count > 0 && elements.First().Id != null)
                {
                    id = (long)elements.First().Id;
                }
                CB.DataSource = elements;
                ComboBox_Helper.CB_visual_reload(CB, id);
            }
        }



        public struct Location_Record
        {
            public long Id { get; set; }
            public DateOnly? Date { get; set; }
            public string ActType { get; set; }
            public string Comment { get; set; }
            public string Name { get; set; }
            public string Authors { get; set; }
            public string Genre { get; set; }
            public string PublicationYear { get; set; }
            public string Code { get; set; }
            public string Id_book { get; set; }
            public string Place { get; set; }

            public Location_Record(long id,
                                    DateOnly date,
                                    string act_type,
                                    string comment,
                                    string book_name,
                                    string authors,
                                    string genre,
                                    string publication_year,
                                    string code,
                                    string id_book,
                                    string place)
            {
                Id = id;
                Date = date;
                ActType = act_type;
                Comment = comment;
                Name = book_name;
                Authors = authors;
                Genre = genre;
                PublicationYear = publication_year;
                Code = code;
                Id_book = id_book;
                Place = place;
            }
        }

        public struct Recommend
        {
            public long Id { get; set; }
            public DateOnly? Date { get; set; }
            public string Source_Type { get; set; }
            public string Source { get; set; }
            public string Recommend_Type { get; set; }
            public string Recommended { get; set; }
            public string Comment { get; set; }

            //++ for projections option
            public long? SourceArtId { get; set; }
            public long? SourceAuthorId { get; set; }
            public long? SourceAnotherId { get; set; }
            public long? ToreadArtId { get; set; }
            public long? ToreadAuthorId { get; set; }
            //-- for projections option
            public Recommend(long id, DateOnly? date, string source_type, string source, string recommend_type, string recommended, string comment,
                  long? sourceArtId, long? sourceAuthorId, long? sourceAnotherId, long? toreadArtId, long? toreadAuthorId)
            {
                Id = id;
                Date = date;
                Source_Type = source_type;
                Source = source;
                Recommend_Type = recommend_type;
                Recommended = recommended;
                Comment = comment;

                SourceArtId = sourceArtId;
                SourceAuthorId = sourceAuthorId;
                SourceAnotherId = sourceAnotherId;
                ToreadArtId = toreadArtId;
                ToreadAuthorId = toreadAuthorId;
            }

        }

        public struct View_Action
        {
            public long? Id { get; set; }
            public DateOnly? Date { get; set; }
            public string ActionType { get; set; }
            public string Comment { get; set; }
            public string Place { get; set; }
            public string Name { get; set; }
        }
    }
}
