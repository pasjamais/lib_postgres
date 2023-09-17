using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lib_postgres.CODE.Queries_LinQ;
using static lib_postgres.Structures;
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

        public static List<Short_Book> Get_Books_Short()
        {
            var books = Queries_from_Views.Get_Books();
            var items = (from b in books
                         select new Short_Book()
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
            // art's title and authors
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
            // rest fields
            var items = (from art in arts_authors
                         join gen in genres on art.art_genre equals gen.Id into sub_genres // LEFT JOIN
                         from sub_g in sub_genres.DefaultIfEmpty()                         // LEFT JOIN
                         join lan_orig in languages on art.lan_orig equals lan_orig.Id into sub_language  // LEFT JOIN
                         from sub_l in sub_language.DefaultIfEmpty()                                      // LEFT JOIN
                         select new Art_and_Author
                         {
                             Id = art.art_id,
                             Name = art.art_name ?? "",
                             Authors = art.authors_concat ?? "",
                             Genre = sub_g == null ? "" : sub_g.Name,                       // LEFT JOIN
                             WritingYear = art.year_orig.HasValue ? art.year_orig.Value.Year.ToString() : "",
                             OrigLanguage = sub_l == null ? "" : sub_l.Name                 // LEFT JOIN
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
        public static List<Short_Art> Get_Short_Arts()
        {
            List<Art_and_Author> arts = Get_Arts();
            List<Short_Art> items = (from art in arts
                                     select new Short_Art()
                         {
                             Id = art.Id,
                             Name = $"{art.Name} | {art.Authors} | {art.OrigLanguage} | {art.Genre} | {art.WritingYear}"    
                         }).ToList().OrderBy(n => n.Name).ToList();
            return items;
        }
    }
}