using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Location : IHas_field_IsDeleted
    {
        public static bool Reset_Element_if_not_New(Location record)
        {
            bool is_new_element = (record.Id == 0) ? true : false;
            if (!is_new_element)
            {
                record.Operation = null;
                record.Book = null;
                record.Place = null;
                record.Owner = null;
                record.Comment = null;
                record.Action = null;
            }
            return is_new_element;
        }

        public static Location Reset_Element(Location record)
        {
            record.Operation = null;
            record.Book = null;
            record.Place = null;
            record.Owner = null;
            record.Comment = null;
            record.Action = null;
            return record;
        }

        public static Location Delete_Element(Location record)
        {
            record.IsDeleted = true;
            return record;
        }
        public static bool _Reset_Element_if_not_New(Location record)
        {
            bool is_new_element = (record.Id == 0) ? true : false;
            if (!is_new_element)
            {
                Reset_Element(record);
            }
            return is_new_element;
        }
        public static Location Update_Location_with_Action_values_and_BookID(Location location, Action action, long? BookID)
        {
            location.Action = action.Id;
            if (action.ActionType == 2) location.Owner = null; //book gone away
                else location.Owner = 1;
            location.Operation = Get_Operation(action.ActionType);
            if (Get_Operation(action.ActionType)) location.Place = action.Place;
                else location.Place = null;
            //!!! В Action хранится Place указанный пользователем в форме, а в Location - действительное расположение, в т. ч. null
            location.Comment = action.Comment;
            location.Book = BookID;
            return location;
        }

        private static bool Get_Operation(long? operation)
        {
            if (operation != null)
                if (operation == 1 || operation == 3 || operation == 5)
                    return true;
                else if (operation == 2 || operation == 4)
                    return false;
                else return false;
            else return false;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<Location> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); ;
            return deleted_items_IDs;
        }
        public static List<Location> Get_Deleted_Items()
        {
            List<Location> items = DB_Agent.Get_Locations();
            List<Location> deleted_items = (from item in items
                                                       where item.IsDeleted is true
                                                       select item).ToList();
            return deleted_items;
        }
    }
}
