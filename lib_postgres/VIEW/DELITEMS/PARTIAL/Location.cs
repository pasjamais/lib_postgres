using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_postgres.CRUD;
using lib_postgres.FORMS;
using Microsoft.EntityFrameworkCore.Storage;

namespace lib_postgres
{
    public partial class Location : IHas_field_IsDeleted
    {
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
