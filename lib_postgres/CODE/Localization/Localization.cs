using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using System.Threading;
using System.Resources;
//using System.Globalisation;
using System.Reflection;
using Microsoft.VisualBasic.Logging;
using lib_postgres.CODE.VIEW.DELITEMS;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

        public static void Get_Local_Captions_for_Simple_Form<T>(out string form_caption, out string label_text)
        {
            string[] result = new string[2];
            Type type = typeof(T);
            string methodName = "Get_Local_Captions_for_Simple_Form";
            if (type.GetMethod(methodName) != null)
                result = (string[])type.GetMethod(methodName).Invoke(null, null);
            if (result != null)
            {
                form_caption = result[0];
                label_text = result[1];
            }
            else
                form_caption = label_text = "";
        }

    }

}
