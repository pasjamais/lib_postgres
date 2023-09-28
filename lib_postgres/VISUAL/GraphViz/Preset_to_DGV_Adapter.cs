using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Preset_to_DGV_Adapter
    {
        public void Prepare_DGV(DataGridView DGV)
        {
            Preset preset = new Preset();
            DGV.Rows.Clear();
            DGV.GridColor = Color.Coral;
            foreach (var key in preset.Graph_Options)
            {
                string[] row = { "graph", key.Key, "", };
                DGV.Rows.Add(row);
            }
           
            foreach (var key in preset.Node_Options)
            {
                string[] row = { "node", key.Key, "", };
                DGV.Rows.Add(row);
            }
        }

        public void Load_Preset_to_DGV(Preset preset , DataGridView DGV)
        {
            DGV.Rows.Clear();
            foreach (var key in preset.Graph_Options)
            {
                string[] row = { "graph", key.Key, key.Value };
                DGV.Rows.Add(row);
            }

            foreach (var key in preset.Node_Options)
            {
                string[] row = { "node", key.Key, key.Value };
                DGV.Rows.Add(row);
            }
        }

        public Preset Get_Preset_from_DGV(DataGridView DGV)
        {
            Preset preset = new Preset();
            for (int i = 0; i < DGV.RowCount;i++)
            {
              string RelatedTo = DGV.Rows[i].Cells["RelatedTo"].Value.ToString() ;
              string property = DGV.Rows[i].Cells["property"].Value.ToString(); 
              string value = DGV.Rows[i].Cells["value"].Value.ToString();
              if (    value == "" || value is null
                || property == "" || property is null
                || RelatedTo == ""|| RelatedTo is null) continue;
              if (RelatedTo.Equals("graph"))
                {
                    if (preset.Graph_Options.ContainsKey(property))
                        preset.Graph_Options[property] = value;
                }
              else if (RelatedTo.Equals("node"))
                {
                    if (preset.Node_Options.ContainsKey(property))
                        preset.Node_Options[property] = value;
                }
            }
            return preset;
        }
    }
}
