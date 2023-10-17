
using lib_postgres.CRUD;

namespace lib_postgres
{
    public partial class ViewHasRead
    {
        public static List<long> Get_Deleted_Items_IDs()
        {
            return ArtRead.Get_Deleted_Items_IDs();
        }
    }
}
