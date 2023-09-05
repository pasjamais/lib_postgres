using lib_postgres.VISUAL.TreeViewViz;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static lib_postgres.FORMS.Form_Recommendation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lib_postgres.FORMS
{
    public partial class Form_Recommendation : Form
    {
        public Form_Recommendation() 
        {
            InitializeComponent();
            treeView_preparation();

            var first_level_node = Graph_Agent.Get_First_Node_by_Text(treeView.Nodes, Graph_Agent.caption_from_books);
            Graph_Agent.Get_Recommendations_for_Arts(first_level_node.Nodes);
            first_level_node.Expand();

            first_level_node = Graph_Agent.Get_First_Node_by_Text(treeView.Nodes, Graph_Agent.caption_from_authors);
            Graph_Agent.Get_Recommendations_for_Authors(first_level_node.Nodes);
            first_level_node.Expand();

            first_level_node = Graph_Agent.Get_First_Node_by_Text(treeView.Nodes, Graph_Agent.caption_from_anothers);
            Graph_Agent.Get_Recommendations_for_Anothers(first_level_node.Nodes);
            first_level_node.Expand();
        }
  
        public void treeView_preparation()
        {
            treeView.Nodes.Add(new TreeNode(Graph_Agent.caption_from_books));
            treeView.Nodes.Add(new TreeNode(Graph_Agent.caption_from_authors));
            treeView.Nodes.Add(new TreeNode(Graph_Agent.caption_from_anothers));
        }

        private void bt_show_art_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            Graph_Agent.Get_Recommendations_for_Arts(treeView.Nodes);     
        }

        private void bt_show_another_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            Graph_Agent.Get_Recommendations_for_Anothers(treeView.Nodes);
        }

        private void bt_show_authors_sources_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            Graph_Agent.Get_Recommendations_for_Authors(treeView.Nodes);
        }
    }
}
