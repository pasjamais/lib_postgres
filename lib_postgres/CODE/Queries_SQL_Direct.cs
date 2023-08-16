﻿using lib_postgres.PARTIAL;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{

    public static class Queries_SQL_Direct
    {
        public static DataTable Fill_DataTable_by_Query(string queryString)
        {
            DataSet ds = new DataSet();
            NpgsqlConnection conn = new NpgsqlConnection(DB_Agent.Get_Connection_String());
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

    }
}