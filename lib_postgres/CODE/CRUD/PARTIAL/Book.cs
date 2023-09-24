using System;
using System.Collections.Generic;
using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class Book : ICan_Erase_by_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.Book element  = DB_Agent.Get_Book(id);
            DB_Agent.db.Books.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }

    }
}
