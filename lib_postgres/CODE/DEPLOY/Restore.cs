using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE.DEPLOY
{
    public class Restore
    {
        private static string skeleton_script_filename = "skeleton.sql";
        private static string RU_init_script_filenam = "RU_ini.sql";
        

        public static void Restore_BD(string backup_file_path, bool need_drop)
        {
            DB_Agent.db.Dispose();
            if (need_drop) Deploy.Drop_BD();
            Deploy.Create_BD();
            Script_Engine.Restore_BD_from_Dump_File(backup_file_path);
            DB_Agent.Renew_Connection();
        }

        public static void Restore_Empty_BD(bool need_drop)
        {
            DB_Agent.db.Dispose();
            if (need_drop) Deploy.Drop_BD();
            Deploy.Create_BD();
            List<string> scripts = new List<string>();
            scripts.Add(skeleton_script_filename);
           // if (Check_If_Need_Init_With_Values())
                scripts.Add(RU_init_script_filenam);
            Script_Engine.Run_PSQL_Script(scripts);
            DB_Agent.Renew_Connection();
        }
        private static bool Check_If_Need_Init_With_Values()
        {
            DialogResult result = MessageBox.Show(
                   "При создании новой базы данных настятельно рекомендуется заполнить её предусмотренными начальными значениями. Вы согласны?",
                   "Сообщение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
                return true;
            else return false;
        }
        public static DialogResult Choose_RestoreBD(OpenFileDialog openFileDialog_BD_Backup)
        {
            if (Directory.Exists(Deploy.backup_dir_path))
                openFileDialog_BD_Backup.InitialDirectory = Deploy.backup_dir_path;
            else
            {
                if (Directory.Exists(Deploy.InitialDirectory))
                    openFileDialog_BD_Backup.InitialDirectory = Deploy.InitialDirectory;
            }
            if (openFileDialog_BD_Backup.ShowDialog() == DialogResult.Cancel)
                return DialogResult.Cancel;
            string filename = openFileDialog_BD_Backup.FileName;
            Restore.Restore_BD(filename, Deploy.is_DB_Exists());
            return DialogResult.OK;
        }
    }
}
