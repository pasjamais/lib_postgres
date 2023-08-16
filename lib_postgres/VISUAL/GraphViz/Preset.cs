using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Preset
    {
        public Dictionary<string, string> Graph_Options = new Dictionary<string, string>         {
            { "graphname", "g" },
            { "layout", "" },
            { "center", "" },
            { "fontname", "" },
            { "nodesep", "" },
            { "ranksep", "" },
            { "rankdir", "" },
            { "size", "" },
            { "ratio", "" },
            { "normalize", "" },
            { "overlap", "" }
        };
     
        public Dictionary<string, string> Node_Options = new Dictionary<string, string>
        {
            { "shape", "" },
            { "width", "" },
            { "height", "" },
            { "fontname", "" }
        };
    }
}
