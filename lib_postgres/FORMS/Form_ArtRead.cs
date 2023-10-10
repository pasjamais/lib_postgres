using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_postgres.QUERIES;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.VIEW.NOTICE;
using lib_postgres.VIEW.SPEC_ENTITIES_VIEWS;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;

namespace lib_postgres.FORMS
{
    public partial class Form_ArtRead : Form
    {
        public Form_ArtRead()
        {
            InitializeComponent();
            ComboBox_Helper.CB_reload_for_Special_Types<Structures.Short_Art>(CB_Art);
            ComboBox_Helper.CB_reload<BookFormat>(CB_BookFormat);
            ComboBox_Helper.CB_reload<Mark>(CB_Mark);
            ComboBox_Helper.CB_reload_for_Special_Types<ViewBook>(CB_PaperBook);
            ComboBox_Helper.CB_reload<Language>(CB_Langue);//russian :3
            if (CB_BookFormat.SelectedValue != null && (long)CB_BookFormat.SelectedValue == 1 ) 
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

        private void Form_ArtRead_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.TryAgain)
                e.Cancel = true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CB_Art_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Propose_Book_for_this_Art();
        }
        private void Propose_Book_for_this_Art()
        {
            var books = Queries_LinQ.Projection_Books_by_ArtID((long)CB_Art.SelectedValue);
            if (books.Count < 1) return;
            ComboBox_Helper.CB_reload_for_Special_Types<ViewBook>(CB_PaperBook, books.FirstOrDefault().Id);
            ComboBox_Helper.CB_reload<BookFormat>(CB_BookFormat, 1);
        }
    }
}
