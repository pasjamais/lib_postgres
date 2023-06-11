using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lib_postgres
{
    public class DB_Agent
    {
        public static libContext db = new libContext();

        #region general
        public static string Get_Connection_String()
        {
            CODE.IniFile ini = new CODE.IniFile(CODE.Data.ini_file_name);
            string? connection_string = ini.Read("connection_string", "GENERAL");
            return connection_string;
        }
        #endregion

        #region Books
        public static void Book_Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        public static Book Get_Book(long id)
        {
            return db.Books.Find(id);
        }

        public static List<ViewBook> Get_ViewBooks()
        {
            return db.ViewBooks.ToList().OrderBy(n => n.Название).ToList();
        }
        public static List<ViewAllRealBook> Get_ViewAllRealBook()
        {
            return db.ViewAllRealBooks.ToList().OrderBy(n => n.Название).ToList();
        }

        public static List<Book> Get_Books()
        {
            return db.Books.ToList().OrderBy(n => n.IdArt).ToList();

        }
        
        public static List<ViewMyBooksInOtherHand> Get_ViewMyBooksInOtherHands()
        {
            return db.ViewMyBooksInOtherHands.ToList().OrderBy(n => n.Дата).ToList();
        }

        #endregion

        #region Arts
        public static List<Art> Get_Arts()
        {
            return db.Arts.ToList().OrderBy(n => n.Name).ToList();
        }

        public static Art Get_Art(long id)
        {
            return db.Arts.Find(id);
        }

        #endregion

        #region Languages
        public static List<Language> Get_Languages()
        {
            return db.Languages.ToList().OrderBy(n => n.Name).ToList();
        }

        public static Language Get_Language(long idLanguage)
        {
            return db.Languages.Find(idLanguage);
        }




        #endregion

        #region Cities
        public static List<City> Get_Cities()
        {
            return db.Cities.ToList().OrderBy(n => n.Name).ToList();
        }

        public static City Get_City(long idCity)
        {
            return db.Cities.Find(idCity);
        }
        #endregion

        #region Publishing_Houses
        public static List<PublishingHouse> Get_Publishing_Houses()
        {
            return db.PublishingHouses.ToList().OrderBy(n => n.Name).ToList();
        }
        public static PublishingHouse Get_Publishing_House(long idPublishing_House)
        {
            return db.PublishingHouses.Find(idPublishing_House);
        }
        #endregion

        #region Series
        public static List<Series> Get_Series()
        {
            return db.Series.ToList().OrderBy(n => n.Name).ToList();
        }

        public static Series Get_Serie(long idSerie)
        {
            return db.Series.Find(idSerie);
        }
        #endregion

        #region Authors
        public static List<Author> Get_Authors()
        {
            return db.Authors.ToList().OrderBy(n => n.Name).ToList();
        }

        public static Author Get_Author(long idAuthor)
        {
            return db.Authors.Find(idAuthor);
        }
        #endregion

        #region Genres
        public static List<Genre> Get_Genres()
        {
            return db.Genres.ToList().OrderBy(n => n.Name).ToList();
        }

        public static Genre Get_Genre(long idGenre)
        {
            return db.Genres.Find(idGenre);
        }
        #endregion

        #region Actions
        public static List<Action> Get_Actions()
        {
            return db.Actions.ToList().OrderBy(n => n.Date).ToList();
        }

        public static Action Get_Action(long id_Action)
        {
            return db.Actions.Find(id_Action);
        }


        #endregion

        #region ActionTypes
        public static List<ActionType> Get_ActionTypes()
        {
            return db.ActionTypes.ToList().OrderBy(n => n.Name).ToList();
        }
        #endregion

        #region Locations
        public static List<Location> Get_Locations()
        {
            return db.Locations.ToList().OrderBy(n => n.Action).ToList();
        }
        public static long? Get_Location_Id_by_Action_Id_and_Book_Id(long? action_id, long? book_id)
        {
            List<Location> locations = db.Locations.ToList();

            var location_id = (from loc in locations
                               where loc.Action == action_id && loc.Book == book_id
                               select loc.Id).ToList().First();
            return location_id;
        }

        public static Location Get_Location(long? id_Location)
        {
            return db.Locations.Find(id_Location);
        }
        #endregion

        #region Possessions
        public static List<Possession> Get_Possessions()
        {
            return db.Possessions.ToList().OrderBy(n => n.Action).ToList();
        }
        #endregion

        #region Places
        public static List<Place> Get_Places()
        {
            return db.Places.ToList().OrderBy(n => n.Name).ToList();
        }
        #endregion

        #region AuthorArts
        public static List<AuthorArt> Get_AuthorArts()
        {
            return db.AuthorArts.ToList().OrderBy(n => n.Art).ToList();
        }

        public static AuthorArt Get_AuthorArt(long id)
        {
            return db.AuthorArts.Find(id);
        }

        public static void Delete_AuthorArt(AuthorArt authorArt)
        {
            db.AuthorArts.Remove(authorArt);
            db.SaveChanges();
        }
        #endregion

        #region Read
        public static List<ArtRead> Get_ArtReads()
        {
            return db.ArtReads.ToList().OrderBy(n => n.Date).ToList();
        }

        public static ArtRead Get_ArtRead(long id)
        {
            return db.ArtReads.Find(id);
        }

        public static List<ViewHasRead> Get_ViewHasReads()
        {
            return db.ViewHasReads.ToList().OrderBy(n => n.Дата).ToList();
        }

        public static ViewHasRead Get_ViewAllRealBook(long id)
        {
            return db.ViewHasReads.Find(id);
        }
        public static void ArtRead_Add(ArtRead artRead)
        {
            db.ArtReads.Add(artRead);
            db.SaveChanges();
        }
        #endregion

        #region BookFormat
        public static List<BookFormat> Get_BookFormats()
        {
            return db.BookFormats.ToList();
        }

        public static BookFormat Get_BookFormat(long id)
        {
            return db.BookFormats.Find(id);
        }
        #endregion

        #region Queries
        public static List<Query> Get_Queries()
        {
            return db.Queries.ToList();
        }

        public static Query Get_Query(long id)
        {
            return db.Queries.Find(id);
        }
        #endregion

        #region Marks
        public static List<Mark> Get_Marks()
        {
            return db.Marks.ToList().OrderBy(n => n.Id).ToList();
        }

        public static Mark Get_Mark(long id)
        {
            return db.Marks.Find(id);
        }
        #endregion

        #region SourceToreadAnother
        public static List<SourceToreadAnother> Get_Another_Sources()
        {
            return db.SourceToreadAnothers.ToList().OrderBy(n => n.Id).ToList();
        }

        public static SourceToreadAnother Get_Another_Source(long id)
        {
            return db.SourceToreadAnothers.Find(id);
        }

        public static bool Is_Exists_Another_Source(string name)
        {
            if (DB_Agent.db.SourceToreadAnothers.ToList().Exists(e => e.Name == name))
                return true;
            else
                return false;
        }

        #endregion
        #region Recommendations
        public static List<ArtToRead> Get_Recommendations()
        {
            return db.ArtToReads.ToList().OrderBy(n => n.Id).ToList();
        }
        public static void Recommendation_Add(ArtToRead item)
        {
            db.ArtToReads.Add(item);
            db.SaveChanges();
        }

        #endregion


    }
}
