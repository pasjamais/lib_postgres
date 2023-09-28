using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.VIEW;

namespace lib_postgres.DEPLOY
{
    public class IniFileInteraction
    {
        public static string Get_Value_from_Settings_File(string key, string section)
        {
            IniFile ini = new IniFile(Data.ini_file_name);
            string? value = ini.Read(key, section);
            return value;
        }

        public static void Set_Value_into_Settings_File(string key, string new_value, string section = "GENERAL")
        {
            IniFile ini = new IniFile(Data.ini_file_name);
            ini.Write(key, new_value, section);
        }
        public static bool String_to_Bool(string key, string section)
        {
            string txt = Get_Value_from_Settings_File(key, section);
            bool is_Erasable;
            try
            {
                is_Erasable = Convert.ToBoolean(txt);
            }
            catch
            {
                return false;
            }
            return is_Erasable;
        }
    }
}
