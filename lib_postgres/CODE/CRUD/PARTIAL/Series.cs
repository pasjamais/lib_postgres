﻿using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class Series : ICan_Erase_by_ID, IGet_All_Elements_of_This_Type
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.Series element = DB_Agent.Get_Serie(id);
            DB_Agent.db.Series.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
        public static dynamic Get_All_Elements_of_This_Type()
        {
            return DB_Agent.Get_Series();
        }
    }
}