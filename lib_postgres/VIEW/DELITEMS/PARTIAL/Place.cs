using lib_postgres.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Place : IHas_field_IsDeleted
    {
    
        public static List<Place> Get_Deleted_Items()
        {
            List<Place> items = DB_Agent.Get_Places();
            List<Place> deleted_items = (from item in items
                                        where item.IsDeleted is true
                                        select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<Place> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList();
            return deleted_items_IDs;
        }
       
    }
}
