﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{

    public static class Code_Queries
    {

            public static List<Art_and_Author> Get_Arts()
        {
            var places = DB_Agent.Get_Places();
            var authors = DB_Agent.Get_Authors();
            var authors_arts = DB_Agent.Get_AuthorArts();
            var languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            var locations = DB_Agent.Get_Locations();
            var books = DB_Agent.Get_Real_Books();
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


        public static void Show_Actions(DataGridView dataGridView)
        {
            var actions = DB_Agent.Get_Actions();
            var action_types = DB_Agent.Get_ActionTypes();
            var places = DB_Agent.Get_Places();
            var items = (from act in actions
                        join act_typ in action_types on act.ActionType equals act_typ.Id
                         //      join pla in places on act.Place equals pla.Id //   если нул надо не соединять   
                         select new
                         {
                             Id = act.Id,
                          //   Действие = act.Name,
                             Примечание = act.Comment,
                             Дата = act.Date,
                          //   Место = pla.Name,
                         //    Тип = act_typ.Name
                         }).ToList().OrderBy(n => n.Дата).ToList(); ;
            dataGridView.DataSource = items;
        }

        public static List<Book_Adopted> Get_Books()
        {
      
            var authors = DB_Agent.Get_Authors();
            var authors_arts = DB_Agent.Get_AuthorArts();
            var languages = DB_Agent.Get_Languages();
            var arts = DB_Agent.Get_Arts();
            var locations = DB_Agent.Get_Locations();
            var books = DB_Agent.Get_Real_Books();
            var genres = DB_Agent.Get_Genres();
            var pubhouse = DB_Agent.Get_Publishing_Houses();
            var cities = DB_Agent.Get_Cities();
            var arts_authors = Get_Arts();
          
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
                             PublicationYear = boo.PublicationYear.HasValue ? boo.PublicationYear.Value.Year.ToString() : "",
                             WritingYear = art.WritingYear,
                             PublishingHouse = pub.Name ?? "",
                             City = cit.Name ?? "",
                             Pages = boo.Pages,
                             Code = boo.Code ?? "",
                             Language = lan_boo.Name ?? "",
                             OrigLanguage = art.OrigLanguage ?? ""
                         }).ToList();
            return items;
        }
        public static dynamic Get_Books_a_la_ancienne()
        {
            var languages = DB_Agent.Get_Languages();
            var books = DB_Agent.Get_Real_Books();
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
        public static dynamic Get_Locations()
        {
            var places = DB_Agent.Get_Places();
            var locations = DB_Agent.Get_Locations();
            var books = Get_Books();
            var items = (from loc in locations
                         join boo in books on loc.Book equals boo.Id
                         join pla in places on loc.Place equals pla.Id
                         select new
                         {
                             loc_record = loc.Id,
                             Размещение = pla.Name ?? "",
                             book_id    = boo.Id.ToString() ?? "",
                             Название   = boo.Name ?? "",
                             Автор_ы    = boo.Authors ?? "",
                             Жанр       = boo.Genre ?? "",
                             Год_издания = boo.PublicationYear ?? "",
                             Год_написания = boo.WritingYear ?? "",
                             Издательство   = boo.PublishingHouse ?? "",
                             Город          = boo.City ?? "",
                             Страниц        = boo.Pages.ToString() ?? "",
                             Шифр           = boo.Code ?? "",
                             Язык_издания   = boo.Language ?? "",
                             Язык_оригинала = boo.OrigLanguage ?? ""
                         }).ToList().OrderBy(n => n.loc_record).ToList();
            return items;
        }

        public static dynamic Get_Action_and_Books(int action_id)
        {
            var places = DB_Agent.Get_Places();
            var locations = DB_Agent.Get_Locations();
            var books = Get_Books();
            var items = (from loc in locations
                         join boo in books on loc.Book equals boo.Id
                         join pla in places on loc.Place equals pla.Id
                         where loc.Action == action_id
                         select new
                         {
                             loc_record = loc.Id,
                             Размещение = pla.Name ?? "",
                             book_id = boo.Id.ToString() ?? "",
                             Название = boo.Name ?? "",
                             Автор_ы = boo.Authors ?? "",
                             Жанр = boo.Genre ?? "",
                             Год_издания = boo.PublicationYear ?? "",
                             Год_написания = boo.WritingYear ?? "",
                             Издательство = boo.PublishingHouse ?? "",
                             Город = boo.City ?? "",
                             Страниц = boo.Pages.ToString() ?? "",
                             Шифр = boo.Code ?? "",
                             Язык_издания = boo.Language ?? "",
                             Язык_оригинала = boo.OrigLanguage ?? ""
                         }).ToList().OrderBy(n => n.loc_record).ToList();
            return items;
        }

    }
}
