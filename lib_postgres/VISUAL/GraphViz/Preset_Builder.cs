using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lib_postgres.VISUAL.GraphViz.Preset;

namespace lib_postgres.VISUAL.GraphViz
{
    public class Preset_Builder
    {
        public List<Preset> presets;
        public Preset_Builder()
        {
            this.presets = new List<Preset>();
            for (int i = 0; i< 5; i++)
                this.presets.Add(Get_Standart_Preset(i));
        }
        
        /// <summary>
        /// return preset with fitted values
        /// zero for empty preset
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// 
        public Preset Get_Standart_Preset(int number)
        {
            Preset preset = new Preset();
            switch (number)
            {
                case 0: //empty preset
                    {
                        preset.Graph_Options["graphname"] = "empty_preset";
                        preset.Graph_Options["layout"] = "";
                        preset.Graph_Options["nodesep"] = "";
                        preset.Graph_Options["ranksep"] = "";
                        preset.Graph_Options["size"] = "";
                        preset.Graph_Options["ratio"] = "";
                        preset.Graph_Options["normalize"] = "";
                        preset.Graph_Options["overlap"] = "";
                        preset.Graph_Options["center"] = "";
                        preset.Graph_Options["fontname"] = "";
                        preset.Graph_Options["rankdir"] = "";
                        preset.Node_Options["shape"] = "";
                        preset.Node_Options["width"] = "";
                        preset.Node_Options["height"] = "";
                        preset.Node_Options["fontname"] = "";
                        return preset;
                    }
                case 1: // good radial preset
                    {
                        preset.Graph_Options["graphname"] = "good_radial_preset";
                        preset.Graph_Options["layout"] = "neato";
                        preset.Graph_Options["nodesep"] = "";
                        preset.Graph_Options["ranksep"] = "";
                        preset.Graph_Options["size"] = "\"40,40\"";
                        preset.Graph_Options["ratio"] = "";
                        preset.Graph_Options["normalize"] = "true";
                        preset.Graph_Options["overlap"] = "scale";
                        preset.Graph_Options["center"] = "";
                        preset.Graph_Options["fontname"] = "\"Helvetica,Arial,sans-serif\"";
                        preset.Graph_Options["rankdir"] = "";
                        preset.Node_Options["shape"] = "record";
                        preset.Node_Options["width"] = ".25";
                        preset.Node_Options["height"] = ".375";
                        preset.Node_Options["fontname"] = "\"Helvetica,Arial,sans-serif\"";
                        return preset;
                    }
                case 2: // flow preset
                    {
                        preset.Graph_Options["graphname"] = " flow_preset";
                        preset.Graph_Options["layout"] = "dot";
                        preset.Graph_Options["nodesep"] = "0.5";
                        preset.Graph_Options["ranksep"] = "10";
                        preset.Graph_Options["size"] = "\"40,40\"";
                        preset.Graph_Options["ratio"] = "";
                        preset.Graph_Options["normalize"] = "";
                        preset.Graph_Options["overlap"] = "";
                        preset.Graph_Options["center"] = "false";
                        preset.Graph_Options["fontname"] = "";
                        preset.Graph_Options["rankdir"] = "LR";
                        preset.Node_Options["shape"] = "";
                        preset.Node_Options["width"] = "";
                        preset.Node_Options["height"] = "";
                        preset.Node_Options["fontname"] = "";
                        return preset;
                    }
                case 3: // radial preset
                    {
                        preset.Graph_Options["graphname"] = "radial_preset";
                        preset.Graph_Options["layout"] = "twopi";
                        preset.Graph_Options["nodesep"] = "";
                        preset.Graph_Options["ranksep"] = "30";
                        preset.Graph_Options["size"] = "";
                        preset.Graph_Options["ratio"] = "auto";
                        preset.Graph_Options["normalize"] = "";
                        preset.Graph_Options["overlap"] = "";
                        preset.Graph_Options["center"] = "";
                        preset.Graph_Options["fontname"] = "";
                        preset.Graph_Options["rankdir"] = "";
                        preset.Node_Options["shape"] = "";
                        preset.Node_Options["width"] = "";
                        preset.Node_Options["height"] = "";
                        preset.Node_Options["fontname"] = "";
                        return preset;
                    }
                case 4: // ugly preset
                    {
                        preset.Graph_Options["graphname"] = "ugly_preset";
                        preset.Graph_Options["layout"] = "dot";
                        preset.Graph_Options["nodesep"] = "";
                        preset.Graph_Options["ranksep"] = "30";
                        preset.Graph_Options["size"] = "";
                        preset.Graph_Options["ratio"] = "auto";
                        preset.Graph_Options["normalize"] = "1";
                        preset.Graph_Options["overlap"] = "scale";
                        preset.Graph_Options["center"] = "";
                        preset.Graph_Options["fontname"] = "";
                        preset.Graph_Options["rankdir"] = "";
                        preset.Node_Options["shape"] = "";
                        preset.Node_Options["width"] = "";
                        preset.Node_Options["height"] = "";
                        preset.Node_Options["fontname"] = "";
                        return preset;
                    }
                default:
                    {
                        return new Preset();
                    }
            }
        }

        public  Preset Get_Preset_by_Index(int index)
        {
            return this.presets[index];
        }
    }
}
