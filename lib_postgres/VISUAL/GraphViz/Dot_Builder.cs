using lib_postgres.VISUAL.GraphViz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lib_postgres.VISUAL.GraphViz.Dot_Translator;
using static lib_postgres.VISUAL.TreeViewViz.Graph_Agent;
using lib_postgres.VISUAL.TreeViewViz;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Dot_Builder
    {
        public Dot_Translator dot_translator;
        public Dot_Builder(Preset preset)
        {
            dot_translator = new Dot_Translator(preset);
        }

        public override string ToString()
        {
            return dot_translator.ToString();
        }

        public void Add_Elements(List<Node_Simple_Element> nodes)
        {
            dot_translator.Add_Elements(nodes);
        }
        public void Add_Relations(List<Relation> relations_to_add)
        {
            dot_translator.Add_Relations(relations_to_add);
        }
    }
}
