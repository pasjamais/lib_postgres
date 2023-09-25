using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class City : ICan_Erase_by_ID, IGet_All_Elements_of_This_Type, IHas_field_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.City element = DB_Agent.Get_City(id);
            DB_Agent.db.Cities.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
          public static dynamic Get_All_Elements_of_This_Type()
        {
            return DB_Agent.Get_Cities();
        }
    }
}
