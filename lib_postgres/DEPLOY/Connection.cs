using lib_postgres.VIEW.DELITEMS;
using lib_postgres.QUERIES;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.VIEW;

namespace lib_postgres.DEPLOY
{
    public class Connection
    {
        private Dictionary<string, string> connection_properties = new Dictionary<string, string>()
        {
            {"Host",    "" },
            {"Port",    "" },
            {"Database","" },
            {"Username","" },
            {"Pooling", "" },
            {"Password","" }
        };
        private string crypt;
        public Connection()
        {
            Load_Connection_Properties();
        }
        private void Load_Connection_Properties()
        {
            foreach (var (key, value) in connection_properties)
            {
                connection_properties[key] = IniFile.Get_Value_from_Settings_File(Data.ini_file_name, key, "CONNECTION");
            }
            crypt = IniFile.Get_Value_from_Settings_File(Data.ini_file_name, "Crypt", "CONNECTION");
            try
            {
                connection_properties["Password"] = Security.Decrypt(crypt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Password error");
                Delete_Crypt_to_INI_File();
            }

        }
        public Dictionary<string, string> Get_Connection_Properties()
        {
            return connection_properties;
        }

        public string Prepare_Connection_String(bool is_system_connection)
        {
            StringBuilder conn_str = new StringBuilder();
            foreach (var (key, value) in connection_properties)
            {
                if (key == "Database" | key == "Pooling" && is_system_connection) continue;
                conn_str.Append($"{key} = {value};");
            }
            return conn_str.ToString();
        }
        public string Get_Password()
        {
            return connection_properties["Password"];
        }
        public void Set_Password(string new_password)
        {
            connection_properties["Password"] = new_password;
            crypt = Security.Encrypt(new_password);
        }
        public void Save_Crypt_to_INI_File()
        {
            IniFileInteraction.Set_Value_into_Settings_File("Crypt", crypt, "CONNECTION");
        }
        public void Delete_Crypt_to_INI_File()
        {
            IniFileInteraction.Set_Value_into_Settings_File("Crypt", "", "CONNECTION");
        }

        public bool has_DB_Tables()
        {
            var result = Queries_SQL_Direct.ExecuteScalar(Deploy.query_tables_quantity, Prepare_Connection_String(false));
            if (result is not null)
                return (long)result >= Deploy.tables_quantity;
            else return false;
        }
        public bool is_DB_Exists()
        {
            return Queries_SQL_Direct.ExecuteScalar(Deploy.query_is_DB_exists, Prepare_Connection_String(true)) is not null;
        }

        public void Drop_BD()
        {
            Queries_SQL_Direct.Execute_Command(Deploy.query_drop_DB, Prepare_Connection_String(true));
        }
        public void Create_BD()
        {
            Queries_SQL_Direct.Execute_Command(Deploy.query_create_DB, Prepare_Connection_String(true));
        }
        public bool Connection_Test()
        {
            return Queries_SQL_Direct.Connection_Test(Prepare_Connection_String(true));

        }
        public string Get_Postgres_Data_Path()
        {
            var rec = Queries_SQL_Direct.Fill_DataTable_by_Query(Deploy.query_get_postgres_path, Prepare_Connection_String(true));
            string path = rec.Rows[0][0].ToString() ?? "";
            path = path.Replace(@"/", @"\");
            return path;
        }
        public string postgres_path()
        {
            return Path.GetDirectoryName(Get_Postgres_Data_Path());
        }

        public string postgres_bin_path()
        {
            return postgres_path() + "\\bin";
        }
        public string pg_dump_exe_path()
        {
            return postgres_bin_path() + "\\" + Deploy.pg_dump_short_name;
        }
        public string psql_exe_path()
        {
            return postgres_bin_path() + "\\" + Deploy.psql_exe_short_name;
        }
        public string pg_restore_exe_path()
        {
            return postgres_bin_path() + "\\" + Deploy.pg_restore_file_name; ;
        }
    }

}
