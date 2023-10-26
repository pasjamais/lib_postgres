using lib_postgres.CRUD;

namespace lib_postgres
{
    public partial class ViewBook
    {
        public static List<long?> Get_HaveRead_Items_IDs()
        {
            List<ArtRead> arts = DB_Agent.Get_ArtReads();
            List<long?> books_read_IDs= (from art in arts
                                        where art.BookId is not null && art.IsDeleted is not true
                                        select art.BookId).ToList();
            return books_read_IDs;
        }
    }
}
