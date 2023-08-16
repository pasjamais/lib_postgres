using lib_postgres.VISUAL.GraphViz;
using lib_postgres.VISUAL.TreeViewViz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lib_postgres.VISUAL.GraphViz.Dot_Translator;

namespace lib_postgres.FORMS
{
    public partial class Form_Graphviz : Form
    {
        public Preset_to_DGV_Adapter preset_to_DGV_Adapter;
        public Preset_Builder preset_Builder;
        public WebBrowser webBrowser;

        public Form_Graphviz()
        {
            InitializeComponent();
            create_Browser();

            preset_Builder = new Preset_Builder();
            preset_to_DGV_Adapter = new Preset_to_DGV_Adapter();
            preset_to_DGV_Adapter.Prepare_DGV(DGV_Graph_Options);

            var CB_items = preset_Builder.presets.Select
                  (p => new
                  {
                      Id = preset_Builder.presets.IndexOf(p),
                      Name = p.Graph_Options["graphname"],
                  }).ToList();

            CB_Preset.DataSource = CB_items;
            CB_Preset.ValueMember = "Id";
            CB_Preset.DisplayMember = "Name";
            CB_Preset.SelectedIndex = 1;
        }

        private void create_Browser()
        {
            webBrowser = new WebBrowser();
            panel_browser.Controls.Add(webBrowser);
            webBrowser.Size = ClientSize;
            webBrowser.Dock = DockStyle.Fill;
        }

        private void BT_Show_Click(object sender, EventArgs e)
        {
            var user_preset = preset_to_DGV_Adapter.Get_Preset_from_DGV(DGV_Graph_Options);

            List<Recomendation> recomendatons = Graph_Agent.Get_Recomendations();
            List<Node_Simple_Element> arts_sources = Graph_Agent.Get_Sources_Arts(recomendatons);
            List<Node_Simple_Element> arts_recommended = Graph_Agent.Get_Recommended_Arts(arts_sources, recomendatons);

            Dot_Builder dot_builder = new Dot_Builder(user_preset);

            dot_builder.Add_Elements(arts_sources);
            dot_builder.Add_Elements(arts_recommended);
            dot_builder.Add_Relations(Graph_Agent.Get_Recomendations_from_Arts_for_Graphviz());

            String graphVizString = dot_builder.ToString();

            string svppath = GraphViz.FileDotEngine.Run(graphVizString);
            webBrowser.Navigate(svppath);
        }
        private void CB_Preset_TextChanged(object sender, EventArgs e)
        {
            preset_to_DGV_Adapter.Load_Preset_to_DGV(preset_Builder.Get_Preset_by_Index(CB_Preset.SelectedIndex), DGV_Graph_Options);
        }

    }
}
