using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.CRUD;
using System.Collections.Generic;

namespace lib_postgres.VIEW.COMBOBOX
{
    public class ComboBox_Helper
    {
        public static void CB_visual_reload(ComboBox CB, long id)
        {
            CB.ValueMember = "Id";
            CB.DisplayMember = "Name";
            CB.SelectedValue = id;
        }

        public static void CB_reload<T>(ComboBox CB) where T : IHas_field_ID
        {
            List<T> elements = CRUD_Item_Determinator.Get_All_Elements_of_This_Type_If_Exist<T>();
            long id = CRUD_Item_Determinator.Get_ID_of_First_Element_if_Exists(elements);
            CB.DataSource = elements;
            CB_visual_reload(CB, id);
        }
        public static void CB_reload<T>(ComboBox CB, long id) where T : IHas_field_ID
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
