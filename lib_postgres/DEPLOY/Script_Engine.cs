using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.CRUD;

namespace lib_postgres.DEPLOY
{
    public class Script_Engine

    {        /// <summary>
             /// Commection properties to their command line keys
             /// </summary>
        private static Dictionary<string, string> cp_keys = new Dictionary<string, string>()
        {
            {"Host",    "-h" },
            {"Port",    "-p" },
            {"Database","-d" },
            {"Username","-U" }
        };
        public static string Get_Quotationned_String(string str)
        {
            return $"\"{str}\"";
        }
        public static string Compose_Commandline_Parameter(string key, string value)
        {
            return $" {key} {value}";
        }

        public static string Prepare_Ordinary_Parameters()
        {
            StringBuilder args = new StringBuilder();
            Connection connection = new Connection();
            Dictionary<string, string> conn_properties = connection.Get_Connection_Properties();
            foreach (var (key, value) in cp_keys)
            {
                args.Append($" {value} {conn_properties[key]}");
            }
            return args.ToString();
        }

        public static void Restore_BD_from_Dump_File(string backup_file_path, string exe_file)
        {
            Connection connection = new Connection();
            string exe = Get_Quotationned_String(exe_file);
            StringBuilder args = new StringBuilder();
            args.Append(Prepare_Ordinary_Parameters());
            args.Append($" {Get_Quotationned_String(backup_file_path)}");
            Run_Process(exe, args.ToString());
        }

        public static void Run_PSQL_Script(List<string> scripts, string exe_file)
        {
            string exe = Get_Quotationned_String(exe_file);
            StringBuilder args = new StringBuilder();
            args.Append(Prepare_Ordinary_Parameters());
            if (scripts is not null && scripts.Count > 0)
            {
                foreach (string filename in scripts)
                    args.Append(Compose_Commandline_Parameter(" -f", Get_Quotationned_String(filename)));
            }
            Run_Process(exe, args.ToString());
        }

        public static void BackupBD()
        {
            Connection connection = new Connection();
            string exe = Get_Quotationned_String(connection.pg_dump_exe_path());
            StringBuilder args = new StringBuilder();
            Dictionary<string, string> conn_properties = connection.Get_Connection_Properties();
            foreach (var (key, value) in cp_keys)
            {
                if (key != "Database")
                    args.Append($" {value} {conn_properties[key]}");
            }
            string libname = conn_properties["Database"];
            string timeStamp = DateTime.Now.ToString("yyyy_MM_dd__HH.mm.ss.ffff");
            string bak = Get_Quotationned_String($"{Backup.Get_Backup_Dir_Name()}\\{libname}_{timeStamp}.backup");
            args.Append($" -F c -b -v -f {bak} {libname}");
            Run_Process(exe, args.ToString());
        }


        public static void Run_Process(string exe, string args)
        {
            Process process = new Process();
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.EnvironmentVariables["PGPASSWORD"] = DB_Agent.Get_Password();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = args;
            process.Start();
            if (process != null && !process.HasExited)
                process.WaitForExit();
        }

    }
}
