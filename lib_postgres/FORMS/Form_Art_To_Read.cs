﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lib_postgres.Structures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace lib_postgres.FORMS
{
    public partial class Form_Art_To_Read : Form
    {
     
        public RadioButton selectedrb_toread, // selectedrb_toread.Tag = true : art; = false : author
                           selectedrb_source; // selectedrb_source.Tag can be "Art", "Author" or "SourceToreadAnother"  
        private Dictionary<string, long> Sources_saved_positions;
        public Form_Art_To_Read(Dictionary<string, long> sources_saved_positions) : this()
        {
            Sources_saved_positions = sources_saved_positions;
            General_Manipulations.CB_reload<Short_Art>(CB_Toread_Art, sources_saved_positions["art_to_read"]);
            General_Manipulations.CB_reload<Author>(CB_Toread_Author, sources_saved_positions["author_to_read"]);
            General_Manipulations.CB_reload<Short_Art>(CB_Source_Art, sources_saved_positions["art"]);
            General_Manipulations.CB_reload<Author>(CB_Source_Author, sources_saved_positions["author"]);
            General_Manipulations.CB_reload<SourceToreadAnother>(CB_Source_Another, sources_saved_positions["another"]);
        
        }
        public Form_Art_To_Read()
        {
            InitializeComponent();
            General_Manipulations.CB_reload<Art>(CB_Toread_Art, 1);
            General_Manipulations.CB_reload<Author>(CB_Toread_Author, 1);
            General_Manipulations.CB_reload<Art>(CB_Source_Art, 1);
            General_Manipulations.CB_reload<Author>(CB_Source_Author, 1);
            General_Manipulations.CB_reload<SourceToreadAnother>(CB_Source_Another, 1);
            RB_Toread_Art.Tag = true;
            RB_Toread_Author.Tag = false;
        }

        private void BT_Add_Art_Click(object sender, EventArgs e)
        {
            var id = Art.Create_Item();
            if (id > 0)
            {   if(CB_Source_Art.SelectedValue != null)
                    CB_Source_Art.Tag = CB_Source_Art.SelectedValue;
                General_Manipulations.CB_reload<Art>(CB_Toread_Art, id);
                General_Manipulations.CB_reload<Art>(CB_Source_Art, (long)CB_Source_Art.Tag);
                RB_Toread_Art.Checked = true;
            }
            DialogResult = DialogResult.None;
           
        }

        private void BT__Toread_Author_Click(object sender, EventArgs e)
        {
            var id = Author.Create_Item();
            if (id > 0)
            {
                if (CB_Source_Author.SelectedValue != null)
                    CB_Source_Author.Tag = CB_Source_Author.SelectedValue;
                General_Manipulations.CB_reload<Author>(CB_Toread_Author, id);
                General_Manipulations.CB_reload<Author>(CB_Source_Author, (long)CB_Source_Author.Tag);
                RB_Toread_Author.Checked = true;
            }
            DialogResult = DialogResult.None;
            
        }

        private void BT__Another_Source_Add_Click(object sender, EventArgs e)
        {
            var id = SourceToreadAnother.Create_Item();
            if (id > 0)
            {
                General_Manipulations.CB_reload<SourceToreadAnother>(CB_Source_Another, id);
                RB_Source_Another.Checked = true;
            }
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

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (selectedrb_toread == null || selectedrb_source == null)
            {
                this.DialogResult = DialogResult.TryAgain;
                Notice_to_Fill_RBs();
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void Form_Art_To_Read_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.TryAgain)
                e.Cancel = true;
        }
        private async void Notice_to_Fill_RBs()
        {
            RB_Source_Another.BackColor = Color.Red;
            RB_Source_Art.BackColor = Color.Red;
            RB_Source_Author.BackColor = Color.Red;
            RB_Toread_Art.BackColor = Color.Red;
            RB_Toread_Author.BackColor = Color.Red;
            await Task.Delay(500);
            DefaultBackColor_to_RBs();
        }

        private void BT_Add_Art_Source_Click(object sender, EventArgs e)
        {
            var id = Art.Create_Item();
            if (id > 0)
            {
                if (CB_Toread_Art.SelectedValue != null)
                    CB_Toread_Art.Tag = CB_Toread_Art.SelectedValue;

                General_Manipulations.CB_reload<Art>(CB_Toread_Art, (long) CB_Toread_Art.Tag);
                General_Manipulations.CB_reload<Art>(CB_Source_Art, id);
                RB_Source_Art.Checked = true;
            }
            DialogResult = DialogResult.None;
            
        }

        private void BT__Toread_Author_Source_Click(object sender, EventArgs e)
        {
            var id = Author.Create_Item();
            if (id > 0)
            {
                if (CB_Toread_Author.SelectedValue != null)
                    CB_Toread_Author.Tag = CB_Toread_Author.SelectedValue;
                General_Manipulations.CB_reload<Author>(CB_Toread_Author, (long)CB_Toread_Author.Tag);
                General_Manipulations.CB_reload<Author>(CB_Source_Author, id);
                RB_Source_Author.Checked = true;
            }
            DialogResult = DialogResult.None;
            


        }

        private void CB_Toread_Art_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Toread_Art.Checked = true;
        }

        private void CB_Toread_Author_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Toread_Author.Checked = true;
        }

        private void CB_Source_Art_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Source_Art.Checked = true;
        }

        private void CB_Source_Author_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Source_Author.Checked = true;
        }

        private void CB_Source_Another_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RB_Source_Another.Checked = true;
        }

        private void DefaultBackColor_to_RBs()
        {
            RB_Source_Another.BackColor = DefaultBackColor;
            RB_Source_Art.BackColor = DefaultBackColor;
            RB_Source_Author.BackColor = DefaultBackColor;
            RB_Toread_Art.BackColor = DefaultBackColor;
            RB_Toread_Author.BackColor = DefaultBackColor;
        }
    }
}