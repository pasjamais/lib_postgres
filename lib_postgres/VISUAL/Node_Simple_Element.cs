using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lib_postgres.VISUAL
{
    public class Node_Simple_Element
    {
        public long? Id_Father;
        public long? Id;
        public string? Text;
        public Node_Simple_Element(long? id, string? text)
        {
            Id = id;
            Text = text;
        }
        public Node_Simple_Element(long? id, string? text, long? id_father) : this(id, text)
        {
            Id_Father = id_father;
        }
    }
}
