using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class ArtRead : ICan_Erase_by_ID
    {//it's ViewHasRead visually
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.ArtRead element = DB_Agent.Get_ArtRead(id);
            DB_Agent.db.ArtReads.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
    }
}
