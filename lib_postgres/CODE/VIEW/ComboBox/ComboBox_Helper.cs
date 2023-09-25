using lib_postgres.CODE.VIEW.ComboBox;
using System.Collections.Generic;

namespace lib_postgres
{
    public class ComboBox_Helper
    {
        public static void CB_visual_reload(ComboBox CB, long id)
        {
            CB.ValueMember = "Id";
            CB.DisplayMember = "Name";
            CB.SelectedValue = id;
        }

        public static void CB_reload<T>(ComboBox CB) where T : CODE.CRUD.IHas_field_ID
        {
            List<T> elements = new List<T>();

            string methodName = "Get_All_Elements_of_This_Type";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                elements = (List<T>)type.GetMethod(methodName).Invoke(null, null);
            long id = 0;
            if (elements != null && elements.Count > 0)
            {
                id = elements.First().Id;
            }
            CB.DataSource = elements;
            CB_visual_reload(CB, id);
        }
        public static void CB_reload<T>(ComboBox CB, long id) where T : CODE.CRUD.IHas_field_ID
        {
            CB_reload<T>(CB);
            CB.SelectedValue = id;
        }
        public static void CB_reload_for_Special_Types<T>(ComboBox CB)
        {
            string methodName = "Show_in_Combobox";
            Type type = typeof(T);
            if (type.GetMethod(methodName) != null)
                type.GetMethod(methodName).Invoke(null, new object[] { CB });
        }
        public static void CB_reload_for_Special_Types<T>(ComboBox CB, long id) 
        {
            CB_reload_for_Special_Types<T>(CB);
            CB.SelectedValue = id;
        }
    }
}
