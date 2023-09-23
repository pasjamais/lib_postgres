using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace lib_postgres.CODE
{

    public static class Queries_SQL_Direct
    {
        public static DataTable Fill_DataTable_by_Query(string queryString, string connection_string)
        {
            DataSet ds = new DataSet();
            NpgsqlConnection conn = new NpgsqlConnection(connection_string);
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(queryString, conn);
            da.Fill(ds);
            conn.Close();
            conn.Dispose();
            return ds.Tables[0];
        }
        public static DataTable Fill_DataTable_by_Query_with_Parameter<T>(string queryString, string parameter_name,T parameter_value)
        {
            DataSet ds = new DataSet();
            NpgsqlConnection conn = new NpgsqlConnection(DB_Agent.Get_Connection_String());
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(queryString, conn);
            command.Parameters.Add(new NpgsqlParameter(parameter_name, NormalType_to_BdType<T>()));
            command.Prepare();
            command.Parameters[0].Value = parameter_value;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(ds);
            conn.Close();
            conn.Dispose();
            return ds.Tables[0];
        }

        public static DbType NormalType_to_BdType<T>()
        {
            Type type = typeof(T);
            if (type is not null)
                if (type == typeof(Int32)) return DbType.Int32;
                else if (type == typeof(Int64)) return DbType.Int64;
                else if (type == typeof(string)) return DbType.String;       
                else                    return DbType.Object;

            else return DbType.Object;
        }

        public static void Execute_Command(string command_text, string conn_string)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_string);
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = command_text;
            command.ExecuteReader();
            conn.Close();
        }

        public static object? ExecuteScalar(string command_text, string conn_string)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(command_text, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static bool Connection_Test(string conn_string)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conn_string))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
