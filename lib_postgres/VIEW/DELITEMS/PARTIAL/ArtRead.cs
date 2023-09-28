using lib_postgres.CRUD;
using lib_postgres.FORMS;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.VIEW.SPEC_ENTITIES_VIEWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lib_postgres
{
    public partial class ArtRead : IHas_field_IsDeleted
    {
      
        public static List<ArtRead> Get_Deleted_Items()
        {
            List<ArtRead> items = DB_Agent.Get_ArtReads();
            List<ArtRead> deleted_items = (from item in items
                                          where item.IsDeleted is true
                                          select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<ArtRead> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); 
            return deleted_items_IDs;
        }
    }
}
