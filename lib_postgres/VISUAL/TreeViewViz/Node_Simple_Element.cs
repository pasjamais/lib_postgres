using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lib_postgres.VISUAL.TreeViewViz
{
    public class Node_Simple_Element
    {
        public long? Id_Parent;
        public long? Id;
        public string? Text;
        public Node_Simple_Element(long? id, string? text)
        {
            Id = id;
            Text = text;
        }
        public Node_Simple_Element(long? id, string? text, long? id_parent) : this(id, text)
        {
            Id_Parent = id_parent;
        }
    }
}
