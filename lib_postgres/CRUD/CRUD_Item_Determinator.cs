using lib_postgres.DEPLOY;
using lib_postgres.Properties;
using lib_postgres.QUERIES;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace lib_postgres.CRUD
{
    public class CRUD_Item_Determinator
    {
        public static long Create_Item<T>()
        {//  Reflection!
         // interface ICan_Create_Item  added to ensure methon presence
            string methodName = "Create_Item";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return (long)type.GetMethod(methodName)
                    .Invoke(null, null);
            else return -1;
        }
        public static long Delete_Item_by_ID<T>(long id)
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return Book.Delete_Item_by_ID(id);
            else if (type == typeof(Art))
                return Art.Delete_Item_by_ID(id);
            else if (type == typeof(City))
                return City.Delete_Item_by_ID(id);
            else if (type == typeof(Author))
                return Author.Delete_Item_by_ID(id);
            else if (type == typeof(Series))
                return Series.Delete_Item_by_ID(id);
            else if (type == typeof(Genre))
                return Genre.Delete_Item_by_ID(id);
            else if (type == typeof(Language))
                return Language.Delete_Item_by_ID(id);
            else if (type == typeof(PublishingHouse))
                return PublishingHouse.Delete_Item_by_ID(id);
            else if (type == typeof(Action))
                return Action.Delete_Item_by_ID(id);
            else if (type == typeof(Mark))
                return Mark.Delete_Item_by_ID(id);
            else if (type == typeof(BookFormat))
                return BookFormat.Delete_Item_by_ID(id);
            else if (type == typeof(Place))
                return Place.Delete_Item_by_ID(id);
            else if (type == typeof(Person))
                return Person.Delete_Item_by_ID(id);
            else if (type == typeof(ArtRead))
                return ArtRead.Delete_Item_by_ID(id);
            else if (type == typeof(ArtToRead))
                return ArtToRead.Delete_Item_by_ID(id);
            else if (type == typeof(SourceToreadAnother))
                return SourceToreadAnother.Delete_Item_by_ID(id);
            else return -1;
        }
        public static long Edit_Item_by_ID<T>(long id)
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return Book.Edit_Book(id);
            if (type == typeof(Author))
                return Author.Edit_Author(id);
            if (type == typeof(Series))
                return Series.Edit_Item_by_ID(id);
            if (type == typeof(Genre))
                return Genre.Edit_Item_by_ID(id);
            if (type == typeof(Language))
                return Language.Edit_Item_by_ID(id);
            if (type == typeof(City))
                return City.Edit_Item_by_ID(id);
            if (type == typeof(Art))
                return Art.Edit_Item_by_ID(id);
            if (type == typeof(PublishingHouse))
                return PublishingHouse.Edit_Item_by_ID(id);
            if (type == typeof(Action))
                return Action.Edit_Item_by_ID(id);
            if (type == typeof(Mark))
                return Mark.Edit_Item_by_ID(id);
            if (type == typeof(BookFormat))
                return BookFormat.Edit_Item_by_ID(id);
            if (type == typeof(Place))
                return Place.Edit_Item_by_ID(id);
            if (type == typeof(Person))
                return Person.Edit_Item_by_ID(id);
            if (type == typeof(ArtToRead))
                return ArtToRead.Edit_Item_by_ID(id);
            if (type == typeof(SourceToreadAnother))
                return SourceToreadAnother.Edit_Item_by_ID(id);
            else return -1;

        }
        public static List<long> Get_Deleted_Items_IDs<T>()
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return DB_Agent.Get_Deleted_Entities_IDs(DB_Agent.Get_Books());
            else if (type == typeof(Art))
                return Art.Get_Deleted_Arts_IDs();
            else if (type == typeof(City))
                return City.Get_Deleted_Cities_IDs();
            else if (type == typeof(Author))
                return Author.Get_Deleted_Authors_IDs();
            else if (type == typeof(Series))
                return Series.Get_Deleted_Series_IDs();
            else if (type == typeof(Genre))
                return Genre.Get_Deleted_Items_IDs();
            else if (type == typeof(Language))
                return Language.Get_Deleted_Items_IDs();
            else if (type == typeof(PublishingHouse))
                return PublishingHouse.Get_Deleted_Items_IDs();
            else if (type == typeof(Action))
                return Action.Get_Deleted_Items_IDs();
            else if (type == typeof(Mark))
                return Mark.Get_Deleted_Items_IDs();
            else if (type == typeof(BookFormat))
                return BookFormat.Get_Deleted_Items_IDs();
            else if (type == typeof(Place))
                return Place.Get_Deleted_Items_IDs();
            else if (type == typeof(Person))
                return Person.Get_Deleted_Items_IDs();
            else if (type == typeof(ArtRead))
                return ArtRead.Get_Deleted_Items_IDs();
            else if (type == typeof(ArtToRead))
                return ArtToRead.Get_Deleted_Items_IDs();
            else if (type == typeof(SourceToreadAnother))
                return SourceToreadAnother.Get_Deleted_Items_IDs();
            else if (type == typeof(Location))
                return Location.Get_Deleted_Items_IDs();
            else return new List<long>();
        }

        public static object Get_All_Items_List_by_Type<T>() where T : new()
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return Queries_from_Views.Get_Books();
            if (type == typeof(Author))
                return DB_Agent.Get_Authors();
            if (type == typeof(Series))
                return DB_Agent.Get_Series();
            if (type == typeof(Art))
                return Queries_LinQ.Get_Arts();
            if (type == typeof(City))
                return DB_Agent.Get_Cities();
            if (type == typeof(Genre))
                return DB_Agent.Get_Genres();
            if (type == typeof(Language))
                return DB_Agent.Get_Languages();
            if (type == typeof(PublishingHouse))
                return DB_Agent.Get_Publishing_Houses();
            if (type == typeof(Action))
                return Prepare_View<T>();
            if (type == typeof(Mark))
                return DB_Agent.Get_Marks();
            if (type == typeof(BookFormat))
                return DB_Agent.Get_BookFormats();
            if (type == typeof(Place))
                return DB_Agent.Get_Places();
            if (type == typeof(Person))
                return DB_Agent.Get_Persons();
            if (type == typeof(ArtRead))
                return DB_Agent.Get_ArtReads();
            if (type == typeof(ArtToRead))
                return Queries_LinQ.Get_All_Recommendations();
            if (type == typeof(SourceToreadAnother))
                return DB_Agent.Get_Another_Sources();
            if (type == typeof(Location))
                return Queries_LinQ.Get_Locations();
            else return -1;
        }

        public static long Erase_Item_by_ID<T>(long id)
        {
            string methodName = "Erase_Item_by_ID";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return (long)type.GetMethod(methodName)
                    .Invoke(null, new object[] { id });
            else return -1;
        }
        public static bool is_Elements_Erasable()
        {
            return IniFileInteraction.String_to_Bool("Delete_Forever", "GENERAL");
        }

        public static void Set_Value_Delete_Forever(bool new_value)
        {
            Connection connection = new Connection();
            string query = new_value ? Resources.Query_Set_On_Delete_Cascade : Resources.Query_Set_On_Delete_Cascade.Replace("CASCADE", "NO ACTION");
            Queries_SQL_Direct.Execute_Command(query, connection.Prepare_Connection_String(false));
            IniFileInteraction.Set_Value_into_Settings_File("Delete_Forever", new_value.ToString());
        }
        public static long Get_ID_of_First_Element_if_Exists<T>(List<T> elements) where T : IHas_field_ID
        {
            long id = 0;
            if (elements != null && elements.Count > 0)
            {
                id = elements.First().Id;
            }
            return id;
        }
        public static List<T> Get_All_Elements_of_This_Type_If_Exist<T>()
        {
            List<T> elements = new List<T>();
            string methodName = "Get_All_Elements_of_This_Type";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                elements = (List<T>)type.GetMethod(methodName).Invoke(null, null);
            return elements ?? new List<T>(); ;
        }

        public static dynamic Prepare_View<T>()
              where T : new()
        {
            string methodName = "Prepare_View";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return type.GetMethod(methodName).Invoke(null, new object[] { });
            else return new T();
        }
    }
}