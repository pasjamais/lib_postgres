using lib_postgres.VISUAL.TreeViewViz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lib_postgres.VISUAL.TreeViewViz.Graph_Agent;
using System.Windows.Forms;
using lib_postgres;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Visualisation_Selector
    {
        public delegate List<Node_Simple_Element> get_list();

        public List<Visualisation> visualisations;

        public Visualisation_Selector()
        {
            this.visualisations = new List<Visualisation>();
            for (int i = 1; i <=6; i++)
                Add_Visualisation(Populate_with_Standart_Visualisation(i));
        }

        public Visualisation Add_Visualisation(Visualisation visualisation)
        {
            visualisations.Add(visualisation);
            return visualisation;
        }

        public Visualisation Get_Visualisation_by_Index(int index)
        {
            return this.visualisations[index];
        }

            public Visualisation Populate_with_Standart_Visualisation(int number)
        {
            Visualisation vis = new Visualisation();
            switch (number)
            {
                case 1:
                    {
                        vis.name = "Книги рекомендуют книги";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Arts);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Arts_for_Arts);
                        return vis;
                    }
                case 2:
                    {
                        vis.name = "Авторы рекомендуют книги";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Authors);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Arts_for_Authors);
                        return vis;
                    }
                case 3:
                    {
                        vis.name = "Другие рекомендуют книги";
                        vis.Add_Source_Methode(Graph_Agent.Get_Another_Sources);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Arts_for_Anothers);
                        return vis;
                    }
                case 4:
                    {
                        vis.name = "Книги рекомендуют авторов";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Arts);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Authors_for_Arts);
                        return vis;
                    }
                case 5:
                    {
                        vis.name = "Авторы рекомендуют авторов";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Authors);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Authors_for_Authors);
                        return vis;
                    }
                case 6:
                    {
                        vis.name = "Другие рекомендуют авторов";
                        vis.Add_Source_Methode(Graph_Agent.Get_Another_Sources);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Authors_for_Anothers); ;
                        return vis;
                    }
                default:
                    {
                        return new Visualisation();
                    }
            }
        }

    }

}
