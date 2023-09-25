using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class ArtToRead : ICan_Erase_by_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.ArtToRead element = DB_Agent.Get_ArtToRead(id);
            DB_Agent.db.ArtToReads.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
    }
}
