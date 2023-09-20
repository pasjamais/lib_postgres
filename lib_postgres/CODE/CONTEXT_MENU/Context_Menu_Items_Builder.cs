using lib_postgres;

namespace lib_postgres
{
    internal class Context_Menu_Items_Builder
    {
        public static ToolStripMenuItem Create_Menu_Item_Using_Form_Resource(string title_key, string method_name)
        {
            string title =  Localization.Get_String_from_Form_Resource<Form_Main>(title_key);
            ToolStripMenuItem item = new ToolStripMenuItem(title);
            item.Tag = title_key; // for programmatically reloading if language changes
            EventHandler method = Get_Main_Form_Method_by_Method_Name(method_name);
            item.Click += method;
            return item;
        }
        public static ToolStripMenuItem Create_Menu_Item_Using_Added_Resource(string title_key, string method_name)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(Localization.Substitute(title_key));
            item.Tag = title_key; // for programmatically reloading if language changes
            EventHandler method = Get_Main_Form_Method_by_Method_Name(method_name);
            item.Click += method;
            return item;
        }
        
        /// <summary>
        /// Sort of a "GetMethod", but for the instantiated object!
        /// </summary>
        public static EventHandler? Get_Main_Form_Method_by_Method_Name(string method_name)
        {
            Form_Main form = Form_Main.GetInstance();
            EventHandler result = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), form, method_name);
            return result;
        }
    }
}
