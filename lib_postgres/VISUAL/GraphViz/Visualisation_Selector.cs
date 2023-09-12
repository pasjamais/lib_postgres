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

        private string Books_recommend_books;
        private string Books_recommend_authors;
        private string Authors_recommend_books;
        private string Authors_recommend_authors;
        private string Others_recommend_books;
        private string Others_recommend_authors;

        public Visualisation_Selector()
        {
            Localization.Substitute(ref Books_recommend_books);
            Localization.Substitute(ref Books_recommend_authors);
            Localization.Substitute(ref Authors_recommend_books);
            Localization.Substitute(ref Authors_recommend_authors);
            Localization.Substitute(ref Others_recommend_books);
            Localization.Substitute(ref Others_recommend_authors);
            

            this.visualisations = new List<Visualisation>();
            for (int i = 1; i <= 6; i++)
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
                        vis.name = Books_recommend_books; //"Книги рекомендуют книги";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Arts);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Arts_for_Arts);
                        return vis;
                    }
                case 2:
                    {
                        vis.name = Authors_recommend_books; // "Авторы рекомендуют книги";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Authors);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Arts_for_Authors);
                        return vis;
                    }
                case 3:
                    {
                        vis.name = Others_recommend_books; // "Другие рекомендуют книги";
                        vis.Add_Source_Methode(Graph_Agent.Get_Another_Sources);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Arts_for_Anothers);
                        return vis;
                    }
                case 4:
                    {
                        vis.name = Books_recommend_authors; // "Книги рекомендуют авторов";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Arts);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Authors_for_Arts);
                        return vis;
                    }
                case 5:
                    {
                        vis.name = Authors_recommend_authors; // "Авторы рекомендуют авторов";
                        vis.Add_Source_Methode(Graph_Agent.Get_Source_Authors);
                        vis.Add_Recommended_Methode(Graph_Agent.Get_Recommended_Authors_for_Authors);
                        return vis;
                    }
                case 6:
                    {
                        vis.name = Others_recommend_authors; // "Другие рекомендуют авторов";
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
