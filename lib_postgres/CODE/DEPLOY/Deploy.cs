using lib_postgres.CODE;
using lib_postgres.FORMS;
using lib_postgres.VISUAL.TreeViewViz;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lib_postgres
{
    public class Deploy
    {
        private static string query_get_postgres_path = @"SELECT setting FROM pg_settings WHERE name = 'data_directory';";
        private static string query_drop_DB = @"DROP DATABASE lib WITH (FORCE);";
        private static string query_create_DB = @"CREATE DATABASE lib";
        private static string query_is_DB_exists = "SELECT 1 FROM pg_database WHERE datname='lib'";
        private static string query_tables_quantity = @"SELECT COUNT(table_name) FROM    information_schema.tables WHERE    table_type = 'BASE TABLE' AND    table_schema NOT IN ('pg_catalog', 'information_schema');";

        private static string output_directory = "output";
        private static string pg_dump_short_name = "pg_dump.exe";
        private static string psql_exe_short_name = "psql.exe";
        private static string skeleton_script_filename = "skeleton.sql";
        private static string script_runner_filename = "run_script.bat";
        private static string global_connection_string;
        private static string output_directory_path;
        private static string postgres_data_path;
        private static string postgres_path;

        public static string postgres_bin_path;
        public static string backup_dir_path;
        public static string pg_dump_exe_path;
        public static string psql_exe_path;

        public static int tables_quantity = 24;


        public static string Output_Directory
        {
            get
            {
                return output_directory_path;
            }

        }
        public Deploy()
        {
            Set_String_Consts();
            Ensure_Directory_Exists_by_Creation(output_directory_path);
            Ensure_Directory_Exists_by_Creation(Backup.Get_Backup_Dir_Name());
            Ensure_DB_Existence();
            Backup.Backup_on_Start();

        }
        private static string Get_Output_Directory_Path()
        {
            return AppDomain.CurrentDomain.BaseDirectory + output_directory;
        }

        public static string Ensure_Directory_Exists_by_Creation(string directory_name)
        {
            string path;
            if (!is_Directory_Exist(directory_name))
                path = Create_Directory(directory_name);
            else path = output_directory_path;
            return path;
        }
        private static bool is_Directory_Exist(string directory_name)
        {
            if (Directory.Exists(directory_name))
                return true;
            else
                return false;
        }

        /// <summary>
        ///return full directory name after creation
        /// </summary>
        /// <param name="directory_name"></param>
        /// <returns></returns>
        private static string Create_Directory(string directory_name)
        {
            return Directory.CreateDirectory(directory_name).ToString();
        }
        private static string Get_Postgres_Data_Path()
        {
            var rec = CODE.Queries_SQL_Direct.Fill_DataTable_by_Query(query_get_postgres_path, global_connection_string);
            string path = rec.Rows[0][0].ToString() ?? "";
            path = path.Replace(@"/", @"\");
            return path;
        }
        public static void Drop_BD()
        {
            Queries_SQL_Direct.Execute_Command(query_drop_DB, global_connection_string);
        }
        public static void Create_BD()
        {
            Queries_SQL_Direct.Execute_Command(query_create_DB, global_connection_string);
        }
        public static void Restore_BD_from_File(string backup_file_path)
        {
            Process.Start(Get_Restore_Bat_file_name(),
                DB_Agent.Get_Password() + @" """ + backup_file_path + @""" """ + Deploy.postgres_bin_path);
        }
        public static void Restore_BD(string backup_file_path, bool need_drop)
        {
            DB_Agent.db.Dispose();
            if (need_drop) Drop_BD();
            Create_BD();
            Restore_BD_from_File(backup_file_path);
            DB_Agent.Renew_Connection();
        }
        public static void Restore_Empty_BD(bool need_drop)
        {
            DB_Agent.db.Dispose();
            if (need_drop) Drop_BD();
            Create_BD();
            Restore_from_Empty_DB_Script();
            DB_Agent.Renew_Connection();
        }

        private static string Get_Restore_Bat_file_name()
        {
            return IniFileInteraction.Get_Value_from_Settings_File("Restore_Bat_file_name", "GENERAL");
        }

        private static string Get_Global_Connection_String()
        {
            return IniFileInteraction.Get_Value_from_Settings_File("global_connection_string", "GENERAL");
        }

        public static void Restore_from_Empty_DB_Script()
        {
            Run_PSQL_Script(skeleton_script_filename);
        }

        public static void Run_PSQL_Script(string script_filename)
        {
            string virgules = "\"";
            string exe = $"{virgules}{Deploy.psql_exe_path}{virgules}";
            string args = $"{DB_Agent.Get_Password()} {script_filename} {exe}";
            Process.Start(script_runner_filename, args);
        }
        private static void Set_String_Consts()
        {
            global_connection_string = Get_Global_Connection_String();
            postgres_data_path = Get_Postgres_Data_Path();
            postgres_path = System.IO.Path.GetDirectoryName(postgres_data_path);
            postgres_bin_path = postgres_path + "\\bin";
            pg_dump_exe_path = postgres_bin_path + "\\" + pg_dump_short_name;
            psql_exe_path = postgres_bin_path + "\\" + psql_exe_short_name;
            backup_dir_path = Backup.Get_Backup_Dir_Path();
            output_directory_path = Get_Output_Directory_Path();
        }
        private static void Ensure_DB_Existence()
        {
            if(!is_DB_Exists() || !has_DB_Tables() )
            {
                    Form_DB form = new Form_DB();
                    var DialogResult = form.ShowDialog();
                    if (DialogResult != DialogResult.OK) Environment.Exit(-1);
                    return;
            }
             else
                return; 
        }

        public static bool is_DB_Exists()
        {
            return CODE.Queries_SQL_Direct.ExecuteScalar(query_is_DB_exists, global_connection_string) is not null;
        }

        public static bool has_DB_Tables()
        {
            var result = CODE.Queries_SQL_Direct.ExecuteScalar(query_tables_quantity, DB_Agent.Get_Connection_String());
            if ( result is not null)
                return (long)result >= tables_quantity;
            else return false;
        }
    }
}

