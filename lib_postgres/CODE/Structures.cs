﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lib_postgres
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
        public struct Short_Art
        {
            public long? Id { get; set; }
            public string Name { get; set; }
            public Short_Art(long id, string name)
            {
                Id = id;
                Name = name;
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
            public Recommend(long id, DateOnly? date, string source_type, string source, string recommend_type, string recommended, string comment)
            {
                Id = id;
                Date = date;
                Source_Type = source_type;
                Source = source;
                Recommend_Type = recommend_type;
                Recommended = recommended;
                Comment = comment;
            }
        }
    }
}