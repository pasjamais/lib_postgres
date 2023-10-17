using lib_postgres.DEPLOY;
using lib_postgres.Properties;
using lib_postgres.QUERIES;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace lib_postgres.CRUD
{
    public class CRUD_Item_Determinator
    {
        public static long Create_Item<T>()
        {//  Reflection!
         // interface ICan_Create_Item  added to ensure methon presence
            string methodName = "Create_Item";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return (long)type.GetMethod(methodName)
                    .Invoke(null, null);
            else return -1;
        }

        public static long Delete_Item_by_ID<T>(long id)
        {
            string methodName = "Delete_Item_by_ID";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return (long)type.GetMethod(methodName)
                    .Invoke(null, new object[] { id });
            else return -1;
        }
        
        public static long Edit_Item_by_ID<T>(long id)
        {
            string methodName = "Edit_Item_by_ID";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return (long)type.GetMethod(methodName)
                    .Invoke(null, new object[] { id });
            else return -1;
        }

        public static List<long> Get_Deleted_Items_IDs<T>()
        {
            string methodName = "Get_Deleted_Items_IDs";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null) 
                return (List<long>)type.GetMethod(methodName).Invoke(null, null);
            else return new List<long>();
        }

        public static long Erase_Item_by_ID<T>(long id)
        {
            string methodName = "Erase_Item_by_ID";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return (long)type.GetMethod(methodName)
                    .Invoke(null, new object[] { id });
            else return -1;
        }
        public static bool is_Elements_Erasable()
        {
            return IniFileInteraction.String_to_Bool("Delete_Forever", "GENERAL");
        }

        public static void Set_Value_Delete_Forever(bool new_value)
        {
            Connection connection = new Connection();
            string query = new_value ? Resources.Query_Set_On_Delete_Cascade : Resources.Query_Set_On_Delete_Cascade.Replace("CASCADE", "NO ACTION");
            Queries_SQL_Direct.Execute_Command(query, connection.Prepare_Connection_String(false));
            IniFileInteraction.Set_Value_into_Settings_File("Delete_Forever", new_value.ToString());
        }
        public static long Get_ID_of_First_Element_if_Exists<T>(List<T> elements) where T : IHas_field_ID
        {
            long id = 0;
            if (elements != null && elements.Count > 0)
            {
                id = elements.First().Id;
            }
            return id;
        }
        public static List<T> Get_All_Elements_of_This_Type_If_Exist<T>()
        {
            List<T> elements = new List<T>();
            string methodName = "Get_All_Elements_of_This_Type";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                elements = (List<T>)type.GetMethod(methodName).Invoke(null, null);
            return elements ?? new List<T>(); ;
        }

        public static dynamic Prepare_View<T>()
              where T : new()
        {
            string methodName = "Prepare_View";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                return type.GetMethod(methodName).Invoke(null, new object[] { });
            else return new T();
        }
    }
}