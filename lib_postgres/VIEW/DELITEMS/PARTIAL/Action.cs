using lib_postgres.CRUD;
using lib_postgres.FORMS;
using lib_postgres.QUERIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace lib_postgres
{
    public partial class Action : IHas_field_IsDeleted
    {
        
        public static List<lib_postgres.Action> Get_Deleted_Items()
        {
            List<lib_postgres.Action> items = DB_Agent.Get_Actions();
            List<lib_postgres.Action> deleted_items = (from item in items
                                                       where item.IsDeleted is true
                                                       select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<lib_postgres.Action> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); 
            return deleted_items_IDs;
        }

    }
}
