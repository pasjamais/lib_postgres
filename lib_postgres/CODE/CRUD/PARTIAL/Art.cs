using System;
using System.Collections.Generic;
using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class Art : ICan_Erase_by_ID, IGet_All_Elements_of_This_Type, IHas_field_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.Art element = DB_Agent.Get_Art(id);
            foreach (Book book in element.Books) 
            {
                DB_Agent.db.Books.Remove(book);
            }
            DB_Agent.db.Arts.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
        public static dynamic Get_All_Elements_of_This_Type()
        {
            return DB_Agent.Get_Arts();
        }
    }
}
