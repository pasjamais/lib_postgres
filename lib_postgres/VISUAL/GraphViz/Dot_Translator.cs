using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static lib_postgres.FORMS.Form_Recommendation;
using static lib_postgres.VISUAL.TreeViewViz.Graph_Agent;
using lib_postgres.VISUAL.TreeViewViz;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Dot_Translator
    {
        private List<element> elements;
        private List<relation> relations;
        private Preset preset;

        public Dot_Translator(Preset preset)
        {
            elements = new List<element>();
            relations = new List<relation>();
            this.preset = preset;
        }

        public void Add_Elements(List<Node_Simple_Element> nodes)
        {
            foreach (var node in nodes)
                elements.Add(new element(node.Id, node.Text));
            elements = elements.Distinct().ToList().OrderBy(d => d.number).ToList();
        }
        public void Add_Relations(List<relation> relations_to_add)
        {
            relations.AddRange(relations_to_add);
            relations = relations.Distinct().ToList().OrderBy(d => d.number).ToList();
        }
        private string Compose_Relations_from_Relations()
        {
            var sb = new StringBuilder();
            foreach (var relais in relations)
                sb.AppendFormat("\n{0} -> {1};", relais.number_parent, relais.number);
            return sb.ToString();
        }
        private string Compose_Nodes_from_Elements()
        {
            var sb = new StringBuilder();
            foreach (var elem in elements)
                sb.AppendFormat("\n{0} [label=\"{1}\"];", elem.number, elem.label);
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Compose_Graph_Section_from_Preset());
            sb.Append(Compose_Node_Section_from_Preset());
            sb.Append(Compose_Nodes_from_Elements());
            sb.Append(Compose_Relations_from_Relations());
            sb.Append(Compose_Cave());
            return sb.ToString();
        }

        private string Compose_Graph_Section_from_Preset()
        {
            var sb = new StringBuilder();
            sb.Append(
                "\ndigraph " + preset.Graph_Options["graphname"] + " {\n");
            foreach (var key in preset.Graph_Options)
            {
                if (!key.Key.Equals("graphname") && key.Value != "")
                    sb.Append(key.Key + " =" + key.Value + ";\n");
            }
            return sb.ToString();
        }

        private string Compose_Node_Section_from_Preset()
        {
            var sb = new StringBuilder();
            sb.Append(
                "\nnode[");
            foreach (var key in preset.Node_Options)
            {
                if (key.Value != "")
                    sb.Append(key.Key + " = " + key.Value + ", ");
            }
            sb.Append(
               "];\n");
            return sb.ToString();
        }

        private string Compose_Cave()
        {
            return "\n}\n";
        }
    }
}
