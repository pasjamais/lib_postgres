using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{
    public class Backup
    {
        public static void BackupBD()
        {
            if (!is_Backup_Dir_Exists())
                Create_Backup_Dir();
            Process.Start(Get_Backup_Bat_file_name(),DB_Agent.Get_Password() + " " + Get_Backup_Dir_Name());
        }
                
        public static void Backup_on_Start()
        {
            if (Backup.is_Backup_on_Start())
                BackupBD();
        }

        private static string Get_Backup_Bat_file_name()
        {
            return IniFileInteraction.Get_Value_from_Settings_File("Backup_Bat_file_name", "GENERAL");
        }
        private static bool is_Backup_Dir_Exists()
        {
            if (Directory.Exists(Get_Backup_Dir_Name()))
                return true;
            else return false;
        }

        private static void Create_Backup_Dir()
        {
            Directory.CreateDirectory(Get_Backup_Dir_Name());
        }

        private static string Get_Backup_Dir_Name()
        {
            return IniFileInteraction.Get_Value_from_Settings_File("BackupDirName", "GENERAL");
        }

        public static bool is_Backup_on_Start()
        {
            string str_Backup_on_Start = IniFileInteraction.Get_Value_from_Settings_File("Backup_on_Start", "GENERAL");
            bool is_Backup_on_Start = Convert.ToBoolean(str_Backup_on_Start);
            if (is_Backup_on_Start) return true;
            else return false;
        }
        public static void Set_Value_Backup_on_Start(bool new_value)
        {
            IniFileInteraction.Set_Value_into_Settings_File("Backup_on_Start", new_value.ToString());
        }

  
    }
}
