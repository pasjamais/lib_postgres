using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{
    public class IniFileInteraction
    {
        public static string Get_Value_from_Settings_File(string key, string section)
        {
            CODE.IniFile ini = new CODE.IniFile(CODE.Data.ini_file_name);
            string? value = ini.Read(key, section);
            return value;
        }

        public static void Set_Value_into_Settings_File(string key, string new_value, string section = "GENERAL")
        {
            CODE.IniFile ini = new CODE.IniFile(CODE.Data.ini_file_name);
            ini.Write(key, new_value, section);
        }


    }
}
