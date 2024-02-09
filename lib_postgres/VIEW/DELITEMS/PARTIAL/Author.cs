using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class Author : IHas_field_IsDeleted 
    {
     
        /// <summary>
        /// for view
        /// </summary>
        /// <returns></returns>
        public static List<Author> Get_Deleted_Authors()
        {
            List<Author> items = DB_Agent.Get_Authors();
            List<Author> deleted_items = (from item in items
                                                       where item.IsDeleted is true
                                                       select item).ToList();
            return deleted_items;
        }
        /// <summary>
        /// for view
        /// </summary>
        /// <returns></returns>
        public static List<long> Get_Deleted_Items_IDs()
        {
            List<Author> deleted_items = Get_Deleted_Authors();
            List<long> deleted_items_IDs = (from item in deleted_items
                                            select item.Id).ToList(); 
            return deleted_items_IDs;
        }
    }
}
