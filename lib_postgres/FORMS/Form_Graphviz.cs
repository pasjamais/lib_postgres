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
using static lib_postgres.VISUAL.TreeViewViz.Graph_Agent;

namespace lib_postgres.FORMS
{
    public partial class Form_Graphviz : Form
    {
        public Preset_to_DGV_Adapter preset_to_DGV_Adapter;
        public Preset_Builder preset_Builder;
        public WebBrowser webBrowser;
        public Visualisation_Selector visualisation_Selector;
        public CB_data_adapter cb_data_adapter;

        public Form_Graphviz()
        {
            InitializeComponent();
            create_Browser();

            preset_Builder = new Preset_Builder();



            this.preset_to_DGV_Adapter = new Preset_to_DGV_Adapter();
            this.preset_to_DGV_Adapter.Prepare_DGV(DGV_Graph_Options);
            this.cb_data_adapter = new CB_data_adapter();

            var CB_items = preset_Builder.presets.Select
                  (p => new
                  {
                      Id = preset_Builder.presets.IndexOf(p),
                      Name = p.Graph_Options["graphname"],
                  }).ToList();

            cb_data_adapter.CB_preparation(CB_Preset, CB_items);
                        
            visualisation_Selector = new Visualisation_Selector(); ;
            var CB_visual = visualisation_Selector.visualisations.Select
                (p => new
                {
                    Id = visualisation_Selector.visualisations.IndexOf(p),
                    Name = p.name,
                }).ToList();
            
            cb_data_adapter.CB_preparation(CB_Visualisation, CB_visual);


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
            string svppath = visualisation_Selector.Get_Visualisation_by_Index(CB_Visualisation.SelectedIndex).Visualize(user_preset);              
            webBrowser.Navigate(svppath);
        }
        private void CB_Preset_TextChanged(object sender, EventArgs e)
        {
            preset_to_DGV_Adapter.Load_Preset_to_DGV(preset_Builder.Get_Preset_by_Index(CB_Preset.SelectedIndex), DGV_Graph_Options);
        }

        private void LL_Graphviz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "https://graphviz.org/");
        }

        private void DGV_Graph_Options_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
