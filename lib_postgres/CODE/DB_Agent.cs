using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lib_postgres
{
    public  class DB_Agent
    {
        public static libContext db = new  libContext();
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

        public static List<Book1> Get_Books()
        {
              return db.Books1.ToList().OrderBy(n => n.Название).ToList(); ;
          
        }
        public static List<Book> Get_Real_Books()
        {
            return db.Books.ToList().OrderBy(n => n.IdArt).ToList(); 

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
            return db.Actions.ToList().OrderBy(n => n.Name).ToList();
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
    }
}
