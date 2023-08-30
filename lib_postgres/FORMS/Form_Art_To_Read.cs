﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace lib_postgres.FORMS
{
    public partial class Form_Art_To_Read : Form
    {
        public RadioButton selectedrb_toread, selectedrb_source;
        private Dictionary<string, long> Sources_saved_positions;
        public Form_Art_To_Read(Dictionary<string, long> sources_saved_positions) :this()
        {
            Sources_saved_positions = sources_saved_positions;
            General_Manipulations.CB_reload<Art>(CB_Toread_Art, 1);
            General_Manipulations.CB_reload<Author>(CB_Toread_Author, 1);
            General_Manipulations.CB_reload<Art>(CB_Source_Art, sources_saved_positions["art"]);
            General_Manipulations.CB_reload<Author>(CB_Source_Author, sources_saved_positions["author"]);
            General_Manipulations.CB_reload<SourceToreadAnother>(CB_Source_Another, sources_saved_positions["another"]);
            RB_Toread_Art.Tag = true;
            RB_Toread_Author.Tag = false;
        }
        public Form_Art_To_Read()
        {
            InitializeComponent();
            General_Manipulations.CB_reload<Art>(CB_Toread_Art, 1);
            General_Manipulations.CB_reload<Author>(CB_Toread_Author, 1);
            General_Manipulations.CB_reload<Art>(CB_Source_Art, 1);
            General_Manipulations.CB_reload<Author>(CB_Source_Author, 1);
            General_Manipulations.CB_reload<SourceToreadAnother>(CB_Source_Another, 1);
        }
   
        private void BT_Add_Art_Click(object sender, EventArgs e)
        {
            var id = Art.Create_Item();
            if (id > 0)
            {
                General_Manipulations.CB_reload<Art>(CB_Toread_Art, id);
                General_Manipulations.CB_reload<Art>(CB_Source_Art, Sources_saved_positions["art"]);
            } 
            DialogResult = DialogResult.None;
        }

        private void BT__Toread_Author_Click(object sender, EventArgs e)
        {
            var id = Author.Create_Item();
            if (id > 0)
            {
                General_Manipulations.CB_reload<Author>(CB_Toread_Author, id);
                General_Manipulations.CB_reload<Author>(CB_Source_Author, 1);
            }
            DialogResult = DialogResult.None;
        }

        private void BT__Another_Source_Add_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.SourceToreadAnother.Add_Another_Source();
            if (id != 0) General_Manipulations.CB_reload<SourceToreadAnother>(CB_Source_Another, id);
            DialogResult = DialogResult.None;
        }

        private void radioButton_ToRead_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            if (rb.Checked)
            {
                selectedrb_toread = rb;
            }
        }
        private void radioButton_Source_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            if (rb.Checked)
            {
                selectedrb_source = rb;
            }
        }

    }
}