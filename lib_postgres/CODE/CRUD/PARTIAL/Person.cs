using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class Person : ICan_Erase_by_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.Person element = DB_Agent.Get_Person(id);
            DB_Agent.db.People.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
    }
}
