using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_postgres.FORMS
{
    public partial class Form_ArtRead : Form
    {
        public Form_ArtRead()
        {
            InitializeComponent();
            General_Manipulations.CB_reload<Art>(CB_Art, 1);
            General_Manipulations.CB_reload<BookFormat>(CB_BookFormat, 1);
            General_Manipulations.CB_reload<Mark>(CB_Mark, 1);
        }
        


        private void Form_ArtRead_Load(object sender, EventArgs e)
        {

        }
    }
}
