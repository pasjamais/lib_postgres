using lib_postgres.CODE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Connection connection = new Connection();
            return connection.Prepare_Connection_String(false);
        }

        public static string _Get_Password()
        {

            return CODE.IniFile.Get_Value_from_Settings_File(CODE.Data.ini_file_name, "Password", "CONNECTION");
        }
        public static string Get_Password()
        {
            Connection connection = new Connection();
            return connection.Get_Password();
        }
        public static void Save_Changes()
        {
            db.SaveChanges();
        }
        public static dynamic  Get_Entities<T>()
        {
            Type type = typeof(T);
            if (type == typeof(Book))
                return Get_Books();
            else return null;
        }

        public static void Renew_Connection()
        {
            db.Dispose();
            libContext new_context = new libContext();
            db = new_context;
        }

        #endregion general

        #region Books
        public static void Book_Add(Book book)
        {
            db.Books.Add(book);
            Save_Changes();
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
        public static void Add_Art(Art item)
        {
            db.Arts.Add(item);
            Save_Changes();
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

        public static void Language_Add(Language language)
        {
            db.Languages.Add(language);
            Save_Changes();
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
        public static void City_Add(City city)
        {
            db.Cities.Add(city);
            Save_Changes();
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

        public static void PublishingHouse_Add(PublishingHouse publishingHouse)
        {
            db.PublishingHouses.Add(publishingHouse);
            Save_Changes();
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

        public static void Serie_Add(Series series)
        {
            db.Series.Add(series);
            Save_Changes();
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
        public static void Author_Add(Author author)
        {
            db.Authors.Add(author);
            Save_Changes();
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
        public static void Genre_Add(Genre genre)
        {
            db.Genres.Add(genre);
            Save_Changes();
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
        public static void Add_Action(Action action)
        {
            db.Actions.Add(action);
            Save_Changes();
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
        public static void Add_Location(Location item)
        {
            db.Locations.Add(item);
            Save_Changes();
        }
        public static Location Get_Location(long? id_Location)
        {
            return db.Locations.Find(id_Location);
        }

        public static Location Get_Location_by_Action_Id_and_Book_Id(long? action_id, long? book_id)
        {
            return db.Locations.Find(Get_Location_Id_by_Action_Id_and_Book_Id(action_id, book_id));
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

        public static Place Get_Place(long id)
        {
            return db.Places.Find(id);
        }

        public static void Add_Place(Place place)
        {
            db.Places.Add(place);
            Save_Changes();
        }
        #endregion

        #region AuthorArts
        public static List<AuthorArt> Get_AuthorArts()
        {
            return db.AuthorArts.ToList();
        }
        //Get_AuthorArts_without_Deleted
        public static List<AuthorArt> _Get_AuthorArts()
        {
            List<AuthorArt>  authorArts = db.AuthorArts.ToList();
            List<AuthorArt> authorArts_actives = (from item in authorArts
                        where item.IsDeleted != true
                        select item).ToList().OrderBy(n => n.Art).ToList(); ;
            return authorArts_actives;
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

        public static void Add_AuthorArt(AuthorArt item)
        {
            db.AuthorArts.Add(item);
            Save_Changes();
        }

        #endregion AuthorArts

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

        public static void Add_BookFormat(BookFormat bookFormat)
        {
            db.BookFormats.Add(bookFormat);
            Save_Changes();
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

        public static void Add_Mark(Mark mark)
        {
            db.Marks.Add(mark);
            Save_Changes();
        }
        #endregion


        #region Person
        public static List<Person> Get_Persons()
        {
            return db.People.ToList().OrderBy(n => n.Id).ToList();
        }

        public static Person Get_Person(long id)
        {
            return db.People.Find(id);
        }

        public static void Add_Person(Person person)
        {
            db.People.Add(person);
            Save_Changes();
        }
        #endregion Person

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
        public static void Add_SourceToreadAnother(SourceToreadAnother item)
        {
            db.SourceToreadAnothers.Add(item);
            Save_Changes();
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
        public static ArtToRead Get_ArtToRead(long id)
        {
            return db.ArtToReads.Find(id);
        }

        #endregion Recommendations

        #region general CRUD
        public static dynamic Get_Deleted_Items<T>(List<T> all_elements)
          where T : CODE.CRUD.IHas_field_IsDeleted
        {
            List<T> deleted_elements = (from elem in all_elements
                                        where elem.IsDeleted is true
                                        select elem).ToList();
            return deleted_elements;
        }
        /// <summary>
        /// Check during new object creation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="all_elements"></param>
        /// <returns></returns>
        public static dynamic Get_First_Deleted_Entity_or_New<T>(List<T> all_elements)
            where T : CODE.CRUD.IHas_field_IsDeleted, new()
        {
            List<T> deleted_elements = Get_Deleted_Items<T>(all_elements);
            T deleted_element = deleted_elements.FirstOrDefault(new T());
            return deleted_element;
        }
      
        public static List<long> Get_Deleted_Entities_IDs<T>(List<T> all_elements)
            where T : CODE.CRUD.IHas_field_ID, CODE.CRUD.IHas_field_IsDeleted
        {
            List<T> deleted_elements = Get_Deleted_Items<T>(all_elements);
            List<long> deleted_elements_id = (from elem in deleted_elements
                                              select elem.Id).ToList();
            return deleted_elements_id;
        }

        /// <summary>
        /// Spec. (non-generalized) method for every instance (for using in Create_Item method)
        /// </summary>
        /// <param name="obj"></param>
        public delegate void write_item_to_BD(object obj);

        /// <summary>
        /// simplified instance creation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <param name="all_elements"></param>
        /// <param name="form_caption"></param>
        /// <param name="label_caption"></param>
        /// <param name="deja_exists_caption"></param>
        /// <param name="add"></param>
        /// <returns></returns>
        public static long Create_Item<T> ( T element,
                                            List<T> all_elements, 
                                            write_item_to_BD add) 
            where T :   CODE.CRUD.IHas_field_IsDeleted, 
                        CODE.CRUD.IHas_field_Name, 
                        CODE.CRUD.IHas_field_ID, new()

        { 
            string f_caption, l_caption, deja_exists_caption;
            Localization.Get_Local_Captions_for_Simple_Form<T>(out f_caption, out l_caption, out deja_exists_caption);
            var new_name = General_Manipulations.simple_element_add(f_caption, l_caption);
            if (new_name != "")
            {
                if (all_elements.Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message(deja_exists_caption);
                    return 0;
                }
                element.Name = new_name;
                if (element.Id == 0)
                {
                    add(element);
                }
                else
                {
                    element.IsDeleted = false;
                    Save_Changes();
                }
                return element.Id;
            }
            else return -1;
        }
        #endregion general CRUD
    }
}
