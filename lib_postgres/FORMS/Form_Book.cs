using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_postgres
{
    public partial class Form_Book : Form
    {
        public Form_Book()
        {
            InitializeComponent();
            CB_Art_Reload(1);
            CB_Book_Language_Reload();
            CB_City_Reload();
            CB_Publishing_House_Reload();
            CB_Series_Reload();
        }

        private void CB_Art_Reload(long id)
        {
            var arts = DB_Agent.Get_Arts();
            var item = (from q in arts
                        where q.Id == id
                        select q).Take(1).First();
            CB_Art.DataSource = arts;
            CB_Art.ValueMember = "Id";
            CB_Art.DisplayMember = "Name";
            CB_Art.SelectedIndex = arts.IndexOf(item);
        }
        private void CB_Book_Language_Reload()
        {
            var languages = DB_Agent.Get_Languages();
            CB_Book_Language.DataSource = languages;
            CB_Book_Language.ValueMember = "Id";
            CB_Book_Language.DisplayMember = "Name";
            var item = (from q in languages
                        where q.Name == "Русский"
                        select q).Take(1).First();
            CB_Book_Language.SelectedIndex = languages.IndexOf(item);
        }

        private void CB_City_Reload()
        {
            CB_City.DataSource      = DB_Agent.Get_Cities();
            CB_City.ValueMember     = "Id";
            CB_City.DisplayMember   = "Name";
            CB_City.SelectedIndex   = 0;
        }
        

        private void CB_Publishing_House_Reload()
        {
            CB_Publishing_House.DataSource = DB_Agent.Get_Publishing_Houses();
            CB_Publishing_House.ValueMember = "Id";
            CB_Publishing_House.DisplayMember = "Name";
            CB_Publishing_House.SelectedIndex = 0;
        }
   
        


        private void CB_Series_Reload()
        {
            CB_Series.DataSource = DB_Agent.Get_Series();
            CB_Series.ValueMember = "Id";
            CB_Series.DisplayMember = "Name";
            CB_Series.SelectedIndex = 0;
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
            CB_Art_Reload(General_Manipulations.Add_Art());
            DialogResult = DialogResult.None;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {

        }

        private void ChB_Pages_CheckedChanged(object sender, EventArgs e)
        {
            label10.Enabled = TB_Pages.Enabled = ChB_Pages.Checked;
        }

        private void ChB_Publication_Year_CheckedChanged(object sender, EventArgs e)
        {
            label7.Enabled = TB_Publication_Year.Enabled = ChB_Publication_Year.Checked;
        }

        private void BT_Add_Maison_Click(object sender, EventArgs e)
        {
        

            CB_Publishing_House_Reload();
            DialogResult = DialogResult.None;
        }
    }
}

