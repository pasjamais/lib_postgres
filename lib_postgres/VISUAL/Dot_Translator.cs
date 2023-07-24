using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static lib_postgres.FORMS.Form_Recommendation;
using static lib_postgres.VISUAL.Graph_Agent;

namespace lib_postgres.VISUAL
{
    public class Dot_Translator
    {
        private List<Graph_Agent.element> elements;
        private List<Graph_Agent.relation> relations;
        public string name;
        public string layout;
        public string ranksep;
        public string ratio;

        private List<Recomendation> recommendations; //not in use
        private List<Node_Simple_Element> nodes;     //not in use      
        private TreeView treeView;                   //not in use
        public Dot_Translator()
        {
            this.elements = new List<element>();
            this.relations = new List<relation>();
            layout = "twopi";
            ranksep = "15";
            ratio = "auto";
        }
        public Dot_Translator(string name, List<Node_Simple_Element> nodes) : this()
        {
            this.name = name;
            this.nodes = nodes;
        }
        public Dot_Translator(string name, TreeView treeView) : this()
        {
            this.name = name;
            this.treeView = treeView;
            this.recommendations = Graph_Agent.Get_Recomendations();
        }

        public void Add_Elements(List<Node_Simple_Element> nodes)
        {
            foreach (var node in nodes)
                elements.Add(new element(node.Id, node.Text));
            elements = elements.Distinct().ToList().OrderBy(d => d.number).ToList();
        }
        public void Add_Relations(List<Graph_Agent.relation> relations_to_add)
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
            sb.Append(Compose_Caption());
            sb.Append(Compose_Nodes_from_Elements());
            sb.Append(Compose_Relations_from_Relations());
            sb.Append(Compose_Cave());
            return sb.ToString();
        }

        private string Compose_Caption()
        {
            var sb = new StringBuilder();
            sb.Append(
                "\ndigraph " + this.name + " {\n"
                + "layout =" + this.layout + ";\n" 
                + "ranksep =" + this.ranksep + ";\n"
                + "ratio =" + this.ratio + ";\n"
                );
            /*  sb.Append(
                  "\ndigraph " + this.name + " {\n"
                  + "size = \"36,36\";\n"
                  + "node[color = grey, style = filled];\n"
                  + "node[fontname = \"Verdana\", size = \"30,30\"];\n"
                  + "graph[fontname = \"Arial\",\n"
                  + "\tfontsize = 36,\n"
                  + "\tstyle = \"bold\",\n"
                  + "\tlabel = \"\n Список \n Список \n\",\n"
                  + "\tssize = \"30,60\"];\n"
                  );*/
            return sb.ToString();
        }
        private string Compose_Cave()
        {
            return "\n}\n";
        }
    }
}
