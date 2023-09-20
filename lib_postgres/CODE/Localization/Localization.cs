using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;
using Microsoft.VisualBasic.Logging;
using lib_postgres.CODE.VIEW.DELITEMS;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace lib_postgres
{
    public class Localization
    {
        public static Dictionary<string, string> UI_langs = new Dictionary<string, string>()
            {
                { "EN", "en-EN" },
                { "FR", "fr-FR" },
                { "RU", "ru-RU" }
            };
        public static Dictionary<string, string> LangID_to_res_files = new Dictionary<string, string>()
            {
                { "EN", "lib_postgres.CODE.Localization.EN" },
                { "FR", "lib_postgres.CODE.Localization.FR" },
                { "RU", "lib_postgres.CODE.Localization.RU" }
            };


        public static CultureInfo current_Culture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
        }

        public static string Get_Short_Language_Name_by_Culture(CultureInfo culture)
        {
            return UI_langs.FirstOrDefault(x => x.Value == culture.Name).Key;
        }

        public static string Substitute(string key)
        {
            string resname = LangID_to_res_files[Get_Short_Language_Name_by_Culture(current_Culture)];
            ResourceManager RM = new ResourceManager(resname, System.Reflection.Assembly.GetExecutingAssembly());
            return RM.GetString(key);
        }
        public static void Substitute(ref string variable, [CallerArgumentExpression("variable")] string key = "")
        {// new feature of C#! - CallerArgumentExpression
            string resname = LangID_to_res_files[Get_Short_Language_Name_by_Culture(current_Culture)];
            ResourceManager RM = new ResourceManager(resname, System.Reflection.Assembly.GetExecutingAssembly());
            variable = RM.GetString(key);
        }
        #region Form_interaction

        public static void Change_Language(Form form, string short_lang_name, ToolStripMenuItem ToolStripMenuItem_UI_Language)
        {
            Set_visibility_to_Actual_ToolStripMenuItem(true,ToolStripMenuItem_UI_Language);
            CultureInfo new_Culture = new CultureInfo(Localization.UI_langs[short_lang_name]);
            Thread.CurrentThread.CurrentUICulture = new_Culture;
            Localization.ApplyCulture(form, new_Culture);
            Show_Actual_Language_in_Top(ToolStripMenuItem_UI_Language);
            Set_visibility_to_Actual_ToolStripMenuItem(false, ToolStripMenuItem_UI_Language);
        }

        public static void Get_Local_Captions_for_Simple_Form<T>(out string form_caption, out string label_text, out string deja_exists_caption)
        {
            string[] result = new string[3];
            Type type = typeof(T);
            string methodName = "Get_Local_Captions_for_Simple_Form";
            if (type.GetMethod(methodName) != null)
                result = (string[])type.GetMethod(methodName).Invoke(null, null);
            if (result != null)
            {
                form_caption = result[0];
                label_text = result[1];
                deja_exists_caption = result[2];
            }
            else
                deja_exists_caption = form_caption = label_text = "";
        }


        /// <summary>
        /// This method was borrowed from Stefan Troschuetz who described 
        /// how it works so well that I wanted to save it in its entirety
        /// method was changed to be external for applicable form (this -- form)
        //  https://www.codeproject.com/Articles/14002/UICultureChanger-component
        /// </summary>
        /// <param name="culture"></param>
        public static void ApplyCulture(Form form, CultureInfo culture)
        {
                 
            // Applies culture to current Thread.
            // Create a resource manager for this Form
            // and determine its fields via reflection.

            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
            FieldInfo[] fieldInfos = form.GetType().GetFields(BindingFlags.Instance |
                BindingFlags.DeclaredOnly | BindingFlags.NonPublic);

            // Call SuspendLayout for Form and all fields derived from Control, so assignment of 
            // localized text doesn't change layout immediately.

            form.SuspendLayout();
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.IsSubclassOf(typeof(Control)))
                {
                    fieldInfos[index].FieldType.InvokeMember("SuspendLayout",
                        BindingFlags.InvokeMethod, null,
                        fieldInfos[index].GetValue(form), null);
                }
            }

            // If available, assign localized text to Form and fields with Text property.


            String text = resources.GetString("$this.Text");
            if (text != null)
                form.Text = text;
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.GetProperty("Text", typeof(String)) != null)
                {
                    text = resources.GetString(fieldInfos[index].Name + ".Text");
                    if (text != null)
                    {
                        fieldInfos[index].FieldType.InvokeMember("Text",
                            BindingFlags.SetProperty, null,
                            fieldInfos[index].GetValue(form), new object[] { text });
                    }
                }
            }

            // Call ResumeLayout for Form and all fields
            // derived from Control to resume layout logic.
            // Call PerformLayout, so layout changes due
            // to assignment of localized text are performed.

            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.IsSubclassOf(typeof(Control)))
                {
                    fieldInfos[index].FieldType.InvokeMember("ResumeLayout",
                            BindingFlags.InvokeMethod, null,
                            fieldInfos[index].GetValue(form), new object[] { false });
                }
            }
            form.ResumeLayout(false);
            form.PerformLayout();
        }

        public static void Initial_Langues_Form_Menu_Load(ToolStripMenuItem ToolStripMenuItem_UI_Language)
        {
            Show_Actual_Language_in_Top(ToolStripMenuItem_UI_Language);
            Set_visibility_to_Actual_ToolStripMenuItem(false, ToolStripMenuItem_UI_Language);

        }
        private static void Show_Actual_Language_in_Top(ToolStripMenuItem ToolStripMenuItem_UI_Language)
        {
            CultureInfo current_Culture = Thread.CurrentThread.CurrentUICulture;
            ToolStripMenuItem_UI_Language.Text = Localization.Get_Short_Language_Name_by_Culture(current_Culture);
        }
        private static void Set_visibility_to_Actual_ToolStripMenuItem(bool is_visible, ToolStripMenuItem ToolStripMenuItem_UI_Language)
        {
            ToolStripMenuItem item = Get_ToolStripMenuItem_according_to_Actual_Culture(ToolStripMenuItem_UI_Language);
            item.Visible = is_visible;
        }
        private static ToolStripMenuItem Get_ToolStripMenuItem_according_to_Actual_Culture(ToolStripMenuItem ToolStripMenuItem_UI_Language)
        {
            string short_lang = Localization.Get_Short_Language_Name_by_Culture(Thread.CurrentThread.CurrentUICulture);
            List<ToolStripMenuItem> lang_menu_items = new List<ToolStripMenuItem>();
            Get_All_ToolStripMenuItem_Controls(ToolStripMenuItem_UI_Language, lang_menu_items);
            return lang_menu_items.Where(x => x.Text == short_lang).First();
        }

        private static void Get_All_ToolStripMenuItem_Controls(ToolStripMenuItem container, List<ToolStripMenuItem> ControlList)
        {// Recursion 
            foreach (ToolStripMenuItem c in container.DropDownItems)
            {
                Get_All_ToolStripMenuItem_Controls(c, ControlList);
                if (c is ToolStripMenuItem) ControlList.Add(c);
            }
        }

        public static void Update_Dynamic_Created_Controls(List<ToolStripMenuItem> dynamic_created_controls)
        {
            foreach (ToolStripMenuItem c in dynamic_created_controls )
            {
                c.Text = Substitute(c.Tag.ToString());
            }
        }

        /// <summary>
        ///  This is how to get access to a Form resource. T is a form type
        /// </summary>
        public static string Get_String_from_Form_Resource<T>(string key)
        {
            Type type = typeof(T);
            var resources = new ResourceManager(type);
            string value = (string)resources.GetObject(key);
            return value ?? "";
        }

        #endregion Form_interaction
    }

}
