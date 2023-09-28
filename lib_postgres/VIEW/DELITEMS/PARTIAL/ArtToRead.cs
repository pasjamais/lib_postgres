using lib_postgres.CRUD;
using lib_postgres.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lib_postgres
{
    public partial class ArtToRead : IHas_field_IsDeleted
    {
      
        public static List<ArtToRead> Get_Deleted_Items()
        {
            List<ArtToRead> items = DB_Agent.Get_Recommendations();
            List<ArtToRead> deleted_items = (from item in items
                                             where item.IsDeleted is true
                                             select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<ArtToRead> deleted_items = Get_Deleted_Items();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); 
            return deleted_items_IDs;
        }
    }
}
