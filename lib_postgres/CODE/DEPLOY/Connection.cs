using lib_postgres.CODE.VIEW.DELITEMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
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

        public Connection()
        {
            Load_Connection_Properties();
        }
        private void Load_Connection_Properties()
        {
            foreach (var (key, value) in connection_properties)
            {
                connection_properties[key] = CODE.IniFile.Get_Value_from_Settings_File(CODE.Data.ini_file_name, key, "CONNECTION");
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


            //Host = localhost; Port = 5432; Database = lib; Username = postgres; Pooling = false; Password = 62013
            //Host=localhost;Port=5432;Username=postgres;Password=62013

        }

    }

}
