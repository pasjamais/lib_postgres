namespace lib_postgres
{
    public partial class ActionType : CODE.CRUD.IHas_field_ID, IGet_All_Elements_of_This_Type
    {
        public static dynamic Get_All_Elements_of_This_Type()
        {
            return DB_Agent.Get_ActionTypes();
        }
    }
}
