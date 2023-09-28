using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;

namespace lib_postgres.DEPLOY
{
    public class Restore
    {
        private static string skeleton_script_filename = "skeleton.sql";

        public static void Restore_BD(string backup_file_path, bool need_drop)
        {
            DB_Agent.db.Dispose();
            Connection connection = new Connection();
            if (need_drop) connection.Drop_BD();
            connection.Create_BD();
            Script_Engine.Restore_BD_from_Dump_File(backup_file_path, connection.pg_restore_exe_path());
            DB_Agent.Renew_Connection();
        }

        public static void Restore_Empty_BD(bool need_drop, bool need_init_with_values)
        {
            Connection connection = new Connection();
            DB_Agent.db.Dispose();
            if (need_drop) connection.Drop_BD();
            connection.Create_BD();
            List<string> scripts = new List<string>();
            scripts.Add(skeleton_script_filename);
            if (need_init_with_values)
                scripts.Add(Localization.Substitute("Filename_Init_Script"));
            Script_Engine.Run_PSQL_Script(scripts, connection.psql_exe_path());
            DB_Agent.Renew_Connection();
        }

        public static DialogResult Choose_RestoreBD(OpenFileDialog openFileDialog_BD_Backup)
        {
            if (Directory.Exists(Backup.Get_Backup_Dir_Path()))
                openFileDialog_BD_Backup.InitialDirectory = Backup.Get_Backup_Dir_Path();
            else
            {
                if (Directory.Exists(Deploy.InitialDirectory))
                    openFileDialog_BD_Backup.InitialDirectory = Deploy.InitialDirectory;
            }
            if (openFileDialog_BD_Backup.ShowDialog() == DialogResult.Cancel)
                return DialogResult.Cancel;
            string filename = openFileDialog_BD_Backup.FileName;
            Connection connection = new Connection();
            Restore_BD(filename, connection.is_DB_Exists());
            return DialogResult.OK;
        }
    }
}
