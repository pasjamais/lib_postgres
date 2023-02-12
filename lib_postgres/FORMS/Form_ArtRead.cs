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
            General_Manipulations.CB_reload<ViewBook>(CB_PaperBook, 1);
            ChB_PaperBook.Enabled = (long)CB_BookFormat.SelectedValue == 1;

        }



        private void Form_ArtRead_Load(object sender, EventArgs e)
        {

        }

        private void CB_BookFormat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ChB_PaperBook.Enabled = (long)CB_BookFormat.SelectedValue == 1; //красиво же
        }

        private void ChB_PaperBook_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void ChB_PaperBook_CheckStateChanged(object sender, EventArgs e)
        {
            CB_PaperBook.Enabled = ChB_PaperBook.Checked;
        }
    }
}
