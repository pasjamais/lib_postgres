using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lib_postgres.VISUAL.Dot_Translator;
using static lib_postgres.VISUAL.Graph_Agent;

namespace lib_postgres.VISUAL
{
    public class Dot_Builder
    {
        public Dot_Translator dot_translator;
        public Dot_Builder(string graph_name, List<Node_Simple_Element> nodes)
        {
            dot_translator = new Dot_Translator(graph_name, nodes);
        }
        public Dot_Builder(string graph_name, TreeView treeView )
        {
            dot_translator = new Dot_Translator(graph_name, treeView);
        }

        public override string ToString()
        {
            return dot_translator.ToString();
        }

        public void Add_Elements(List<Node_Simple_Element> nodes)
        {
            dot_translator.Add_Elements(nodes);
        }
        public void Add_Relations(List<Graph_Agent.relation> relations_to_add)
        {
            dot_translator.Add_Relations(relations_to_add);
        }
    }
}
