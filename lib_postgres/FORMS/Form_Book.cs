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
            General_Manipulations.CB_reload<Art>(CB_Art, 1);
            General_Manipulations.CB_reload<Language>(CB_Book_Language, 3);//русский по-умолчанию
            General_Manipulations.CB_reload<City>(CB_City, 1);
            General_Manipulations.CB_reload<PublishingHouse>(CB_Publishing_House, 1);
            General_Manipulations.CB_reload<Series>(CB_Series, 1);
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
            var id = PARTIAL.Art.Add_Art();
            if (id > 0) General_Manipulations.CB_reload<Art>(CB_Art, id);
            DialogResult = DialogResult.None;
        }


        private void BT_Add_Maison_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.PublishingHouse.Add_PubHouse();
            if (id != 0) General_Manipulations.CB_reload<PublishingHouse>(CB_Publishing_House, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_Langue_Book_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Language.Add_Language();
            if (id != 0) General_Manipulations.CB_reload<Language>(CB_Book_Language, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_City_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.City.Add_City();
            if (id != 0) General_Manipulations.CB_reload<City>( CB_City, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_Serie_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Series.Add_Serie();
            if (id != 0) General_Manipulations.CB_reload<Series>(CB_Series, id);
            DialogResult = DialogResult.None;
        }
    }
}

