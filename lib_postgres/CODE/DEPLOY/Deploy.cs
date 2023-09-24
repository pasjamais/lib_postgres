using lib_postgres.CODE;
using lib_postgres.CODE.DEPLOY;
using lib_postgres.FORMS;

namespace lib_postgres
{

    public class Deploy
    {
        public static string query_get_postgres_path = @"SELECT setting FROM pg_settings WHERE name = 'data_directory';";
        public static string query_drop_DB = @"DROP DATABASE lib WITH (FORCE);";
        public static string query_create_DB = @"CREATE DATABASE lib";
        public static string query_is_DB_exists = "SELECT 1 FROM pg_database WHERE datname='lib'";
        public static string query_tables_quantity = @"SELECT COUNT(table_name) FROM    information_schema.tables WHERE    table_type = 'BASE TABLE' AND    table_schema NOT IN ('pg_catalog', 'information_schema');";
        private static string output_directory = "output";
        public static string pg_dump_short_name = "pg_dump.exe";
        public static string psql_exe_short_name = "psql.exe";
        public static string pg_restore_file_name = "pg_restore.exe";
        private static string output_directory_path = AppDomain.CurrentDomain.BaseDirectory + output_directory;
        public static string InitialDirectory = @"C:\";
        public static int tables_quantity = 24;
        public static string Output_Directory
        { get { return output_directory_path; } }

        private Connection connection = new Connection();

        public Deploy()
        {
            if (connection.Get_Password() == "")
                Call_DB_Form();
            if (!connection.Connection_Test())
                Call_DB_Form();
            Ensure_DB_Existence();
            File_Level_Operations.Ensure_Directory_Exists_by_Creation(output_directory_path);
            File_Level_Operations.Ensure_Directory_Exists_by_Creation(Backup.Get_Backup_Dir_Name());
            Backup.Backup_on_Start();
        }

        private void Ensure_DB_Existence()
        {
            if (!connection.is_DB_Exists() || !connection.has_DB_Tables())
            {
                Call_DB_Form();
            }
        }

        private static DialogResult Call_DB_Form()
        {
            Form_DB form = new Form_DB();
            var DialogResult = form.ShowDialog();
            if (DialogResult != DialogResult.OK) Environment.Exit(-1);
            return DialogResult;
        }

    }
}
