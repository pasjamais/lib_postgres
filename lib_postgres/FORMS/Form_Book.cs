﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.VIEW.NOTICE;
using lib_postgres.VIEW.SPEC_ENTITIES_VIEWS;

namespace lib_postgres
{
    public partial class Form_Book : Form
    {
        public Form_Book()
        {
            InitializeComponent();
            ComboBox_Helper.CB_reload_for_Special_Types<Structures.Short_Art>(CB_Art);
            ComboBox_Helper.CB_reload<Language>(CB_Book_Language);// Langue default
            ComboBox_Helper.CB_reload<City>(CB_City);
            ComboBox_Helper.CB_reload<PublishingHouse>(CB_Publishing_House);
            ComboBox_Helper.CB_reload<Series>(CB_Series);
        }

        private void ChB_Publishing_House_CheckedChanged(object sender, EventArgs e)
        {
           label8.Enabled = CB_Publishing_House.Enabled = ChB_Publishing_House.Checked;
        }

        private void ChB_Series_CheckedChanged(object sender, EventArgs e)
        {
            label15.Enabled = CB_Series.Enabled = ChB_Series.Checked;
        }

        private void ChB_City_CheckedChanged(object sender, EventArgs e)
        {
            label9.Enabled = CB_City.Enabled = ChB_City.Checked; 
        }

        private void ChB_Language_CheckedChanged(object sender, EventArgs e)
        {
            label6.Enabled = CB_Book_Language.Enabled = ChB_Language.Checked; 
        }

        private void BT_Add_Art_Click(object sender, EventArgs e)
        {
            var id = Art.Create_Item();
            if (id > 0) ComboBox_Helper.CB_reload_for_Special_Types<Structures.Short_Art>(CB_Art, id);
            DialogResult = DialogResult.None;
        }


        private void BT_Add_Maison_Click(object sender, EventArgs e)
        {
            var id = PublishingHouse.Create_Item();
            if (id != 0) ComboBox_Helper.CB_reload<PublishingHouse>(CB_Publishing_House, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_Langue_Book_Click(object sender, EventArgs e)
        {
            var id = Language.Create_Item();
            if (id != 0) ComboBox_Helper.CB_reload<Language>(CB_Book_Language, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_City_Click(object sender, EventArgs e)
        {
            var id = City.Create_Item();
            if (id != 0) ComboBox_Helper.CB_reload<City>( CB_City, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_Serie_Click(object sender, EventArgs e)
        {
            var id = Series.Create_Item();
            if (id != 0) ComboBox_Helper.CB_reload<Series>(CB_Series, id);
            DialogResult = DialogResult.None;
        }


        private void TB_KeyPress_Check(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (CB_Art.SelectedValue == null || (System.Int64)CB_Art.SelectedValue < 1)
            {
                this.DialogResult = DialogResult.TryAgain;
                Notice notice = new Notice();
                notice.Notice_by_Color<Label_Colorized>(Label_Art);
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_Book_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.TryAgain)
                e.Cancel = true;
        }
    }
}

