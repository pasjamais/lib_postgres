using lib_postgres.VISUAL.TreeViewViz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lib_postgres.VISUAL.TreeViewViz.Graph_Agent;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Visualisation 
    {
        public delegate List<Node_Simple_Element> get_list();
        public get_list source;
        public get_list recommended;
        public string name { get; set; }

        public Visualisation(get_list source, get_list recommended, string name)
        {
            this.source = source;
            this.recommended = recommended;
            this.name = name;
        }
    
        public Visualisation()
        {
           
        }
        public void Add_Source_Methode(get_list methode)
        {
           this.source = methode;
        }

        public void Add_Recommended_Methode(get_list methode)
        {
            this.recommended = methode;
        }

        public string Visualize(Preset preset)
        {
            return engine(preset,
                      source(),
                      recommended());
        }

        private string engine (Preset preset,
                          List<Node_Simple_Element> sources,
                          List<Node_Simple_Element> recommended)
        {
            List<Recomendation> recomendatons = Graph_Agent.Get_Recommendations();
            List<Relation> relations = Get_Relations(recommended);
            Dot_Builder dot_builder = new Dot_Builder(preset);
            dot_builder.Add_Elements(sources);
            dot_builder.Add_Elements(recommended);
            dot_builder.Add_Relations(relations);

            String graphVizString = dot_builder.ToString();

            string svppath = FileDotEngine.Run(graphVizString);
            return svppath;
        }
        private List<Relation> Get_Relations(List<Node_Simple_Element> recommended)
        {
            List<Relation> relations = new List<Relation>();
            foreach (var s in recommended)
            {
                relations.Add(new Relation(s));
            }
            return relations;
        }


    }
}
