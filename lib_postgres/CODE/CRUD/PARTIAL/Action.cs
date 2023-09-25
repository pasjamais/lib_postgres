using lib_postgres.CODE.CRUD;

namespace lib_postgres
{
    public partial class Action : ICan_Erase_by_ID
    {
        public static long Erase_Item_by_ID(long id)
        {
            lib_postgres.Action element = DB_Agent.Get_Action(id);
            DB_Agent.db.Actions.Remove(element);
            DB_Agent.Save_Changes();
            return element.Id;
        }
    }
}
