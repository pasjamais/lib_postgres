using System;
using System.Collections.Generic;
using lib_postgres.CRUD;
using lib_postgres.VIEW.COMBOBOX;

namespace lib_postgres
{
    public partial class ViewBook
    {
        public static long Delete_Item_by_ID(long id)
        {
            return Book.Delete_Item_by_ID(id);
        }
        public static long Edit_Item_by_ID(long id)
        {
            return Book.Edit_Item_by_ID(id);
        }
    }
}
