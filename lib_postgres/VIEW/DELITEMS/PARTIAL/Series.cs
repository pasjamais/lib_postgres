using lib_postgres.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Series : IHas_field_IsDeleted
      {
        
        public static List<lib_postgres.Series> Get_Deleted_Series()
        {
            List<lib_postgres.Series> items = DB_Agent.Get_Series();
            List<lib_postgres.Series> deleted_items = (from item in items
                                                       where item.IsDeleted is true
                                                       select item).ToList();
            return deleted_items;
        }
        public static List<long> Get_Deleted_Series_IDs()
        {
            List<lib_postgres.Series> deleted_items = Get_Deleted_Series();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); 
            return deleted_items_IDs;
        }
    }
}
