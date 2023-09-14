using lib_postgres.CODE;
using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class SourceToreadAnother : IHas_field_IsDeleted, IHas_field_ID, IHas_field_Name, ICan_Create_Item
    {
        public static DB_Agent.write_item_to_BD creation_method;
        public static long Add_Another_Source()
        {
            var new_name = General_Manipulations.simple_element_add("Добавить другой источник рекомендации", "Наименование:");
            if (new_name != "")
            {
                if (DB_Agent.Is_Exists_Another_Source(new_name))
                {
                    General_Manipulations.simple_message("Источник уже существует");
                    return 0;
                }
                else
                {
                    SourceToreadAnother element = new SourceToreadAnother();
                    element.Name = new_name;
                    DB_Agent.db.SourceToreadAnothers.Add(element);
                    DB_Agent.db.SaveChanges();
                    return element.Id;
                }
            }
            else return 0;
        }

        public static long Create_Item()
        {
            SourceToreadAnother element = DB_Agent.Get_First_Deleted_Entity_or_New<SourceToreadAnother>(DB_Agent.Get_Another_Sources());

            creation_method = delegate (object obj)
            {
                DB_Agent.Add_SourceToreadAnother(element);
            };

            return DB_Agent.Create_Item<SourceToreadAnother>(element,
                                                            DB_Agent.Get_Another_Sources(),
                                                            creation_method);
        }

        public static List<SourceToreadAnother> Get_Deleted_Items()
        {
            List<SourceToreadAnother> items = DB_Agent.Get_Another_Sources();
            List<SourceToreadAnother> deleted_items = (from item in items
                                        where item.IsDeleted is true
                                        select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<SourceToreadAnother> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
        public static long Delete_Item_by_ID(long id)
        {
            SourceToreadAnother item = DB_Agent.Get_Another_Source(id);
            if (item.IsDeleted.HasValue)
                item.IsDeleted = !item.IsDeleted;
            else
                item.IsDeleted = true;
            DB_Agent.db.SaveChanges();
            return item.Id;
        }
        public static long Edit_Item_by_ID(long id)
        {
            SourceToreadAnother element = DB_Agent.Get_Another_Source(id);
            var new_name = General_Manipulations.simple_element_modify("Изменить  иной источник рекомендации", "Новое наименование:", element.Name);
            if (new_name != "")
            {
                if (DB_Agent.db.PublishingHouses.ToList().Exists(e => e.Name == new_name))
                {
                    General_Manipulations.simple_message("Источник рекомендации уже существует");
                    return 0;
                }
                element.Name = new_name;
                DB_Agent.db.SaveChanges();
                return element.Id;
            }
            else return -1;
        }
    }
}
