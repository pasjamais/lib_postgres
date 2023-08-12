using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE.CRUD
{
    public class CRUD_Item_Determinator
    {
        public static long Create_Item<T>()
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return PARTIAL.Book.Create_Book();
            if (type == typeof(Series))
                return PARTIAL.Series.Create_Item();
            if (type == typeof(Genre))
                return PARTIAL.Genre.Create_Item();
            if (type == typeof(Language))
                return PARTIAL.Language.Create_Item();
            else return -1;

        }
        public static long Delete_Item_by_ID<T>(long id)
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return PARTIAL.Book.Delete_Item_by_ID(id);
            else if (type == typeof(Art))
                return PARTIAL.Art.Delete_Item_by_ID(id);
            else if (type == typeof(City))
                return PARTIAL.City.Delete_Item_by_ID(id);
            else if (type == typeof(Author))
                return PARTIAL.Author.Delete_Item_by_ID(id);
            else if (type == typeof(Series))
                return PARTIAL.Series.Delete_Item_by_ID(id);
            else if (type == typeof(Genre))
                return PARTIAL.Genre.Delete_Item_by_ID(id);
            else if (type == typeof(Language))
                return PARTIAL.Language.Delete_Item_by_ID(id);
            else return -1;
        }
        public static long Edit_Item_by_ID<T>(long id)
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return PARTIAL.Book.Edit_Book(id);
            if (type == typeof(Author))
                return PARTIAL.Author.Edit_Author(id);
            if (type == typeof(Series))
                return PARTIAL.Series.Edit_Item_by_ID(id);
            if (type == typeof(Genre))
                return PARTIAL.Genre.Edit_Item_by_ID(id);
            if (type == typeof(Language))
                return PARTIAL.Language.Edit_Item_by_ID(id);
            else return -1;

        }
        public static List<long> Get_Deleted_Items_IDs<T>()
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return PARTIAL.Book.Get_Deleted_Books_IDs();
            else if (type == typeof(Art))
                return PARTIAL.Art.Get_Deleted_Arts_IDs();
            else if (type == typeof(City))
                return PARTIAL.City.Get_Deleted_Cities_IDs();
            else if (type == typeof(Author))
                return PARTIAL.Author.Get_Deleted_Authors_IDs();
            else if (type == typeof(Series))
                return PARTIAL.Series.Get_Deleted_Series_IDs();
            else if (type == typeof(Genre))
                return PARTIAL.Genre.Get_Deleted_Series_IDs();
            else if (type == typeof(Language))
                return PARTIAL.Language.Get_Deleted_Items_IDs();
            else return new List<long>();
        }

        public static object  Get_All_Items_List_by_Type<T>()
        {
            Type type = typeof(T);
            if (type == typeof(ViewBook))
                return Queries_from_Views.Get_Books();
            if (type == typeof(Author))
                return DB_Agent.Get_Authors();
            if (type == typeof(Series))
                return DB_Agent.Get_Series();
            if (type == typeof(Art))
                return CODE.Queries_LinQ.Get_Arts();
            if (type == typeof(City))
                return DB_Agent.Get_Cities();
            if (type == typeof(Genre))
                return DB_Agent.Get_Genres();
            if (type == typeof(Language))
                return DB_Agent.Get_Languages();
            else return -1;
        }
    }
}
