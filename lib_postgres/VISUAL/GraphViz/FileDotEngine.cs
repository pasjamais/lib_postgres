// https://www.codeproject.com/Articles/1164156/Using-Graphviz-in-your-project-to-create-graphs-fr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public static class FileDotEngine
    {
        public static string Run(string dot)
        {
            string executable = @".\external\dot.exe";
            string output = @".\external\testgraph.dt";
            string svgfilename = AppDomain.CurrentDomain.BaseDirectory + "external\\testgraph.dt.svg";
            File.WriteAllText(output, dot);

            System.Diagnostics.Process process = new System.Diagnostics.Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.FileName = executable;
            process.StartInfo.Arguments = string.Format(@"-Tsvg -O {0}", output);
            process.Start();
            process.WaitForExit();
            if (File.Exists(svgfilename))
                return svgfilename;
            else
                return "";
        }
    }
}
