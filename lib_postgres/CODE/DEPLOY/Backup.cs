using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE.DEPLOY
{
    public class Backup
    {
        public static void BackupBD()
        {
            File_Level_Operations.Ensure_Directory_Exists_by_Creation(Get_Backup_Dir_Name());
            Script_Engine.BackupBD();
        }

        public static void Backup_on_Start()
        {
            if (is_Backup_on_Start())
                BackupBD();
        }

        public static string Get_Backup_Dir_Name()
        {
            return IniFileInteraction.Get_Value_from_Settings_File("BackupDirName", "GENERAL");
        }

        public static bool is_Backup_on_Start()
        {
            return IniFileInteraction.String_to_Bool("Backup_on_Start", "GENERAL");
        }
        public static void Set_Value_Backup_on_Start(bool new_value)
        {
            IniFileInteraction.Set_Value_into_Settings_File("Backup_on_Start", new_value.ToString());
        }
        public static string Get_Backup_Dir_Path()
        {
            return AppDomain.CurrentDomain.BaseDirectory + Get_Backup_Dir_Name();
        }
    }
}
