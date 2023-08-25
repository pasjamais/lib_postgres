using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class PublishingHouse : IHas_field_IsDeleted, IHas_field_ID, IHas_field_Name, ICan_Create_Item
    {
        public static DB_Agent.write_item_to_BD creation_method;
        public static long Create_Item()
        {
            PublishingHouse element = DB_Agent.Get_First_Deleted_Entity_or_New<PublishingHouse>(DB_Agent.Get_Publishing_Houses());

            creation_method = delegate (object obj)
            {
                DB_Agent.PublishingHouse_Add(element);
            };

            return DB_Agent.Create_Item<PublishingHouse>(element,
                                                            DB_Agent.Get_Publishing_Houses(),
                                                            "Добавить издательство",
                                                            "Название:",
                                                            "Издательство уже существует",
                                                            creation_method);
        }
        public static long Edit_Item_by_ID(long id)
        {
            lib_postgres.PublishingHouse element = DB_Agent.Get_Publishing_House(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить издательство", "Новое название:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Издательство уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }
        public static List<lib_postgres.PublishingHouse> Get_Deleted_Items()
        {
            List<lib_postgres.PublishingHouse> items = DB_Agent.Get_Publishing_Houses();
            List<lib_postgres.PublishingHouse> deleted_items = (from item in items
                                                         where item.IsDeleted is true
                                                         select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<lib_postgres.PublishingHouse> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
        public static long Delete_Item_by_ID(long id)
        {
            lib_postgres.PublishingHouse item = DB_Agent.Get_Publishing_House(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
    }
}
