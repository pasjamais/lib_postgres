using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lib_postgres.CODE
{
    public static class Queries_LinQ
    {
        public static List<ViewAllRealBook> Get_Books_by_Place_Name(string place_name)
        {
            var books = Queries_from_Views.Get_Books_in_their_Places();
            var items = (from book in books
                         where book.Место == place_name
                         select book
                         ).ToList();
            return items;
        }
        public static dynamic Get_Books_Short()
        {
            var books = Queries_from_Views.Get_Books();
            var items = (from b in books
                         select new
                         {
                             Id = b.Id,
                             Name = b.Название + " | " + b.АвторЫ + " | "
                                       + b.Жанр + " | " + b.Издательство + " | " + b.Шифр
                         }).ToList().OrderBy(n => n.Name).ToList();
            return items;
        }

        public static List<Art_and_Author> Get_Arts()
        {
            var places = DB_Agent.Get_Places();
            var authors = DB_Agent.Get_Authors();
            var authors_arts = DB_Agent.Get_AuthorArts();
            var languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            var locations = DB_Agent.Get_Locations();
            var books = DB_Agent.Get_Books();
            var genres = DB_Agent.Get_Genres();
            var pubhouse = DB_Agent.Get_Publishing_Houses();
            var cities = DB_Agent.Get_Cities();
            // название и авторы
            var arts_authors = (from art in arts
                                join aa in authors_arts on art.Id equals aa.Art
                                join aut in authors on aa.Author equals aut.Id
                                group aut by new { art } into g
                                select new
                                {
                                    art_name = g.Key.art.Name,
                                    art_id = g.Key.art.Id,
                                    art_genre = g.Key.art.Genre,
                                    lan_orig = g.Key.art.OrigLanguage,
                                    year_orig = g.Key.art.WritingYear,
                                    authors_concat = String.Join(",", g.Select(x => x.Name))
                                }).ToList();
            // остальные поля
            var items = (from art in arts_authors
                         join gen in genres on art.art_genre equals gen.Id
                         join lan_orig in languages on art.lan_orig equals lan_orig.Id
                         select new Art_and_Author
                         {
                             Id = art.art_id,
                             Name = art.art_name ?? "",
                             Authors = art.authors_concat ?? "",
                             Genre = gen.Name ?? "",
                             WritingYear = art.year_orig.HasValue ? art.year_orig.Value.Year.ToString() : "",
                             OrigLanguage = lan_orig.Name ?? ""
                         }).ToList();
            return items;
        }
        public static List<Art_and_Author> Get_Arts_by_LanguageName(string language_name)
        {
            List<Language> Get_Languages = DB_Agent.Get_Languages();
            List<Art_and_Author> arts = CODE.Queries_LinQ.Get_Arts();
            return (from a in arts
                    where a.OrigLanguage == language_name
                    select a).ToList();
        }

        public static List<Book_Adopted> Get_Books()
        {
            var arts_authors = Get_Arts();
            var books = DB_Agent.Get_Books();
            var pubhouse = DB_Agent.Get_Publishing_Houses();
            var cities = DB_Agent.Get_Cities();
            var languages = DB_Agent.Get_Languages();
            var genres = DB_Agent.Get_Genres();
            var items = (from boo in books
                         join art in arts_authors on boo.IdArt equals art.Id
                         join pub in pubhouse on boo.IdPublishingHouse equals pub.Id
                         join cit in cities on boo.IdCity equals cit.Id
                         join lan_boo in languages on boo.IdLanguage equals lan_boo.Id
                         select new Book_Adopted
                         {
                             Id = boo.Id,

                             Name = art.Name ?? "",
                             Authors = art.Authors ?? "",
                             Genre = art.Genre ?? "",
                             WritingYear = art.WritingYear ?? "",
                             OrigLanguage = art.OrigLanguage ?? "",

                             PublishingLanguage = lan_boo.Name ?? "",
                             PublicationYear = boo.PublicationYear.HasValue ? boo.PublicationYear.Value.Year.ToString() : "",
                             PublishingHouse = pub.Name ?? "",
                             City = cit.Name ?? "",
                             Pages = boo.Pages,
                             Code = boo.Code ?? ""
                         }).ToList();
            return items;
        }
        public static dynamic Get_Books_a_la_ancienne()
        {
            var languages = DB_Agent.Get_Languages();
            var books = DB_Agent.Get_Books();
            var pubhouse = DB_Agent.Get_Publishing_Houses();
            var cities = DB_Agent.Get_Cities();
            var arts_authors = Get_Arts();
            var items = (from boo in books
                         join art in arts_authors on boo.IdArt equals art.Id
                         join pub in pubhouse on boo.IdPublishingHouse equals pub.Id
                         join cit in cities on boo.IdCity equals cit.Id
                         join lan_boo in languages on boo.IdLanguage equals lan_boo.Id
                         select new
                         {
                             Id = boo.Id,
                             Name = art.Name ?? "",
                             Автор_ы = art.Authors ?? "",
                             Жанр = art.Genre ?? "",
                             Год_издания = boo.PublicationYear.HasValue ? boo.PublicationYear.Value.Year.ToString() : "",
                             Издательство = pub.Name ?? "",
                             Город = cit.Name ?? "",
                             Страниц = boo.Pages.ToString() ?? "",
                             Шифр = boo.Code ?? "",
                             Язык_издания = lan_boo.Name ?? "",
                             Язык_оригинала = art.OrigLanguage ?? "",
                             Год_написания = art.WritingYear ?? ""
                         }).ToList();
            return items;
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
        public static dynamic Get_Locations()
        {
            var actions = DB_Agent.Get_Actions();
            var places = DB_Agent.Get_Places();
            var locations = DB_Agent.Get_Locations();
            var books = Get_Books();
            var act_type = DB_Agent.Get_ActionTypes();
            var items = (from loc in locations
                         join boo in books on loc.Book equals boo.Id
                         join pla in places on loc.Place equals pla.Id into PL // LEFT JOIN
                         from pl in PL.DefaultIfEmpty()                      // LEFT JOIN

                         join acc in actions on loc.Action equals acc.Id
                         join actype in act_type on acc.ActionType equals actype.Id
                         select new Location_Record()
                         {
                             Id = loc.Id,
                             Date = acc.Date,
                             ActType = actype.Name,
                             Comment = acc.Comment,
                             Name = boo.Name ?? "",
                             Authors = boo.Authors ?? "",
                             Genre = boo.Genre ?? "",
                             PublicationYear = boo.PublicationYear ?? "",
                             Code = boo.Code ?? "",
                             Id_book = boo.Id.ToString() ?? "",
                             Place = pl == null ? "" : pl.Name, // LEFT JOIN
                         }).ToList().OrderByDescending(n => n.Date).ToList();

            return items;
        }
        public static dynamic _Get_Locations()
        {
            var actions = DB_Agent.Get_Actions();
            var places = DB_Agent.Get_Places();
            var locations = DB_Agent.Get_Locations();
            var books = Get_Books();
            var act_type = DB_Agent.Get_ActionTypes();
            var items = (from loc in locations
                         join boo in books   on loc.Book equals boo.Id
                         join pla in places  on loc.Place equals pla.Id into PL // LEFT JOIN
                            from pl in PL.DefaultIfEmpty()                      // LEFT JOIN

                         join acc in actions on loc.Action equals acc.Id
                         join actype in act_type on acc.ActionType equals actype.Id
                         select new
                         {
                             Id = loc.Id,
                             Дата = acc.Date,
                             действие = actype.Name,
                             Примечание = acc.Comment,
                             Название = boo.Name ?? "",
                             Автор_ы = boo.Authors ?? "",
                             Жанр = boo.Genre ?? "",
                             Годизд = boo.PublicationYear ?? "",
                             Шифр = boo.Code ?? "",
                             Idкниги = boo.Id.ToString() ?? "",
                             Размещение = pl == null ? "" : pl.Name, // LEFT JOIN
                         }).ToList().OrderByDescending(n => n.Дата).ToList();
            return items;
        }

        public static dynamic Get_Recommendations()
        {
            var arts_authors = Get_Arts();
            var recs = DB_Agent.Get_Recommendations();
            var temp = (from rec in recs
                        join art_source in arts_authors on rec.SourceArtId equals art_source.Id
                        select new
                        {
                            Id = rec.Id,
                            Date = rec.Date,
                            Art_Source = art_source.Name + " | " + art_source.Authors,
                            Comment = rec.Comment,
                            ToreadArtId = rec.ToreadArtId
                        }).ToList();
            arts_authors = Get_Arts();
            var result = (from tem in temp
                          join art_toread in arts_authors on tem.ToreadArtId equals art_toread.Id
                          select new
                          {
                              Id = tem.Id,
                              Date = tem.Date,
                              Art_ToRead = art_toread.Name + " | " + art_toread.Authors,
                              Art_Source = tem.Art_Source,
                              Comment = tem.Comment
                          }).ToList();
            return result;
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

        public static dynamic Get_All_Recommendations()
        {
          
            var recs = DB_Agent.Get_Recommendations();
            var _arts_authors = Get_Arts();
            var _art_sources = (from rec in recs
                               join art_source in _arts_authors on rec.SourceArtId equals art_source.Id
                               select new
                               {
                                   Id = rec.Id,
                                   Date = rec.Date,
                                   Source = art_source.Name + " | " + art_source.Authors,
                                   Comment = rec.Comment,
                                   ToreadArtId = rec.ToreadArtId,
                                   ToreadAuthorId = rec.ToreadAuthorId
                               }).ToList();
            _arts_authors = Get_Arts();
            var arts_to_arts = (from art_source in _art_sources
                         join art_toread in _arts_authors on art_source.ToreadArtId equals art_toread.Id
                         select new Recommend()
                         {
                             Id = art_source.Id,
                             Date = art_source.Date,
                             Source_Type = lib_postgres.Localization.Substitute("Book"),
                             Source = art_source.Source,
                             Recommend_Type = lib_postgres.Localization.Substitute("Book"),
                             Recommended = art_toread.Name + " | " + art_toread.Authors,
                             Comment = art_source.Comment
                         }).ToList();
            var _authors = DB_Agent.Get_Authors();
            var arts_to_authors = (from art_source in _art_sources
                                   join author in _authors on art_source.ToreadAuthorId equals author.Id
                                   select new Recommend()
                                {
                                    Id = art_source.Id,
                                    Date = art_source.Date,
                                       Source_Type = lib_postgres.Localization.Substitute("Book"),
                                       Source = art_source.Source,
                                    Recommend_Type = lib_postgres.Localization.Substitute("Author"),
                                    Recommended = author.Name,
                                    Comment = art_source.Comment
                                }).ToList();
/////////////////

            var _authors_sources = (from rec in recs
                                   join author in _authors on rec.SourceAuthorId equals author.Id
                               select new
                               {
                                   Id = rec.Id,
                                   Date = rec.Date,
                                   Source = author.Name,
                                   Comment = rec.Comment,
                                   ToreadArtId = rec.ToreadArtId,
                                   ToreadAuthorId = rec.ToreadAuthorId
                               }).ToList();
            var authors_to_arts = (from author_source in _authors_sources
                                   join art_toread in _arts_authors on author_source.ToreadArtId equals art_toread.Id
                                   select new Recommend()
                                {
                                    Id = author_source.Id,
                                    Date = author_source.Date,
                                       Source_Type = lib_postgres.Localization.Substitute("Author"),
                                       Source = author_source.Source,
                                       Recommend_Type = lib_postgres.Localization.Substitute("Book"),
                                       Recommended = art_toread.Name + " | " + art_toread.Authors,
                                    Comment = author_source.Comment
                                }).ToList();
            var authors_to_authors = (from author_source in _authors_sources
                                   join author in _authors on author_source.ToreadAuthorId equals author.Id
                                   select new Recommend()
                                   {
                                       Id = author_source.Id,
                                       Date = author_source.Date,
                                       Source_Type = lib_postgres.Localization.Substitute("Author"),
                                       Source = author_source.Source,
                                       Recommend_Type = lib_postgres.Localization.Substitute("Author"),
                                       Recommended = author.Name,
                                       Comment = author_source.Comment
                                   }).ToList();

            /////////////////
            var _anothers = DB_Agent.Get_Another_Sources();
            var _another_sources = (from rec in recs
                                    join another in _anothers on rec.SourceAnotherId equals another.Id
                                    select new
                                    {
                                        Id = rec.Id,
                                        Date = rec.Date,
                                        Source = another.Name,
                                        Comment = rec.Comment,
                                        ToreadArtId = rec.ToreadArtId,
                                        ToreadAuthorId = rec.ToreadAuthorId
                                    }).ToList();
            var another_to_arts = (from another in _another_sources
                                   join art_toread in _arts_authors on another.ToreadArtId equals art_toread.Id
                                   select new Recommend()
                                   {
                                       Id = another.Id,
                                       Date = another.Date,
                                       Source_Type = lib_postgres.Localization.Substitute("Another"),
                                       Source = another.Source,
                                       Recommend_Type = lib_postgres.Localization.Substitute("Book"),
                                       Recommended = art_toread.Name + " | " + art_toread.Authors,
                                       Comment = another.Comment
                                   }).ToList();
            var another_to_authors = (from another in _another_sources
                                      join author in _authors on another.ToreadAuthorId equals author.Id
                                      select new Recommend()
                                      {
                                          Id = another.Id,
                                          Date = another.Date,
                                          Source_Type = lib_postgres.Localization.Substitute("Another"),
                                          Source = another.Source,
                                          Recommend_Type = lib_postgres.Localization.Substitute("Author"),
                                          Recommended = author.Name,
                                          Comment = another.Comment
                                      }).ToList();
            var result = arts_to_arts.Union(arts_to_authors)
                             .Union(authors_to_arts).Union(authors_to_authors)
                             .Union(another_to_arts).Union(another_to_authors)
                             .OrderBy(n => n.Id).ToList(); 
            return result;
        }

}
}
