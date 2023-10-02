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
        public long? Id_Parent { get; set; }
        public long? Id { get; set; }
        public string? Text { get; set; }
        public Types Short_Element_Type { get; set; }
        public Types Short_Parent_Type { get; set; }
        public enum Types
        {
            Art = 'B',
            Author = 'A',
            Another = 'M',
            None = '\0'
        }
        public Node_Simple_Element(long? id, string? text)
        {
            Id = id;
            Text = text;
        }
        public Node_Simple_Element(long? id, string? text, long? id_parent) : this(id, text)
        {
            Id_Parent = id_parent;
        }

        public Node_Simple_Element()
        {
        }
    }
}
