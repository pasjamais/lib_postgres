using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Genre
    {
        public static long Create_Item()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить жанр", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.db.Genres.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Жанр уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.Genre element = new lib_postgres.Genre();
                    element.Name = new_name;
                    DB_Agent.db.Genres.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return -1;
        }
     
        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.Genre element = DB_Agent.Get_Genre(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить жанр", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Genres.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Жанр уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }
        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.Genre item = DB_Agent.Get_Genre(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
        public static List<lib_postgres.Genre> Get_Deleted_Items()
        {
            List<lib_postgres.Genre> items = DB_Agent.Get_Genres();
            List<lib_postgres.Genre> deleted_items = (from item in items
                                                       where item.IsDeleted is true
                                                       select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<lib_postgres.Genre> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
    }
}
