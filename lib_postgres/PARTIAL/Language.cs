using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.PARTIAL
{
    public partial class Language
    {
        public static long Create_Item()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить язык", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.db.Languages.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Язык уже существует");
                    return 0;
                }
                else
                {
                    lib_postgres.Language element = new lib_postgres.Language();
                    element.Name = new_name;
                    DB_Agent.db.Languages.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return -1;
        }
      
        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.Language element = DB_Agent.Get_Language(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить язык", "Новое наименование:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.Languages.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Язык уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }

        public static List<lib_postgres.Language> Get_Deleted_Items()
        {
            List<lib_postgres.Language> items = DB_Agent.Get_Languages();
            List<lib_postgres.Language> deleted_items = (from item in items
                                                      where item.IsDeleted is true
                                                      select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<lib_postgres.Language> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.Language item = DB_Agent.Get_Language(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
    }
}
