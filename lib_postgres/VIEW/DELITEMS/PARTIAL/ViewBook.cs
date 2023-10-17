using lib_postgres.CRUD;

namespace lib_postgres
{
    public partial class ViewBook
    {
        public static List<long> Get_Deleted_Items_IDs()
        {
            return DB_Agent.Get_Deleted_Entities_IDs(DB_Agent.Get_Books());
        }
    }
}
