using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class BookFormat : IHas_field_IsDeleted, IHas_field_ID, IHas_field_Name, ICan_Create_Item
    {
        public static DB_Agent.write_item_to_BD creation_method;

        public static long Create_Item()
        {
            BookFormat element = DB_Agent.Get_First_Deleted_Entity_or_New<BookFormat>(DB_Agent.Get_BookFormats());

            creation_method = delegate (object obj)
            {
                DB_Agent.Add_BookFormat(element);
            };

            return DB_Agent.Create_Item<BookFormat>(element,
                                                            DB_Agent.Get_BookFormats(),
                                                            creation_method);
        }
        public static long Edit_Item_by_ID(long id)
        {
            BookFormat element = DB_Agent.Get_BookFormat(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить формат", "Новый формат:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.BookFormats.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Формат уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }

        public static List<BookFormat> Get_Deleted_Items()
        {
            List<BookFormat> items = DB_Agent.Get_BookFormats();
            List<BookFormat> deleted_items = (from item in items
                                              where item.IsDeleted is true
                                              select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<BookFormat> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
        public static long Delete_Item_by_ID(long id)
        {
            BookFormat item = DB_Agent.Get_BookFormat(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
    }
}
