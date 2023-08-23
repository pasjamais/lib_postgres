using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Series
    {

        public static long Create_Item()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить серию книг", "Название:");
            if (new_name != "")
            {
                if (DB_Agent.db.Series.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Серия уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.Series element = new lib_postgres.Series();
                    element.Name = new_name;
                    DB_Agent.db.Series.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }

        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.Series element = DB_Agent.Get_Serie(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить серию", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Series.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Серия уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return 0;
        }
        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.Series item = DB_Agent.Get_Serie(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
        public static List<lib_postgres.Series> Get_Deleted_Series()
        {
            List<lib_postgres.Series> items = DB_Agent.Get_Series();
            List<lib_postgres.Series> deleted_items = (from item in items
                                                       where item.IsDeleted is true
                                                       select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Series_IDs()
        {
            List<lib_postgres.Series> deleted_items = Get_Deleted_Series();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
    }
}
