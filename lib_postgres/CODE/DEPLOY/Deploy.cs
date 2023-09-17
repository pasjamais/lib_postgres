using lib_postgres.CODE;
using lib_postgres.CODE.DEPLOY;
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
using static lib_postgres.VISUAL.TreeViewViz.Graph_Agent;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
        private static string pg_restore_file_name = "pg_restore.exe";
        private static string global_connection_string;
        private static string output_directory_path;
        private static string postgres_data_path;
        private static string postgres_path;

        public static string postgres_bin_path;
        public static string backup_dir_path;
        public static string pg_dump_exe_path;
        public static string psql_exe_path;
        public static string pg_restore_exe_path;
        public static string InitialDirectory = @"C:\";
        public static int tables_quantity = 24;
        public static string Output_Directory
            { get { return output_directory_path; } }
        public Deploy()
        {   
            Set_String_Consts();
            File_Level_Operations.Ensure_Directory_Exists_by_Creation(output_directory_path);
            File_Level_Operations.Ensure_Directory_Exists_by_Creation(Backup.Get_Backup_Dir_Name());
            Ensure_DB_Existence();
            Backup.Backup_on_Start();
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
      
        private static void Set_String_Consts()
        {
            Connection connection = new Connection();
            global_connection_string = connection.Prepare_Connection_String(true);
            postgres_data_path = Get_Postgres_Data_Path();
            postgres_path = System.IO.Path.GetDirectoryName(postgres_data_path);
            postgres_bin_path = postgres_path + "\\bin";
            pg_dump_exe_path = postgres_bin_path + "\\" + pg_dump_short_name;
            psql_exe_path = postgres_bin_path + "\\" + psql_exe_short_name;
            pg_restore_exe_path = postgres_bin_path + "\\" + pg_restore_file_name;
            backup_dir_path = Backup.Get_Backup_Dir_Path();
            output_directory_path = AppDomain.CurrentDomain.BaseDirectory + output_directory;
        }
        private static void Ensure_DB_Existence()
        {
            if (!is_DB_Exists() || !has_DB_Tables())
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
            if (result is not null)
                return (long)result >= tables_quantity;
            else return false;
        }


    }
}

