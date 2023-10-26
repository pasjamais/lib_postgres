
using lib_postgres.CRUD;

namespace lib_postgres
{
    public partial class Art
    {
        public static List<long> Get_HaveRead_Items_IDs()
        {
            List<ArtRead> arts = DB_Agent.Get_ArtReads();
            List<long> arts_read_IDs = (from art in arts
                                                   where art.IsDeleted is not true
                                                   select art.ArtId).ToList();
            return arts_read_IDs;
        }
    }
}
