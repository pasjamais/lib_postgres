using lib_postgres.QUERIES;
using lib_postgres.VIEW;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.LOCALIZATION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_postgres.CRUD;

namespace lib_postgres.FORMS
{
    public partial class Form_Action : Form
    {

        public List<ViewBook> action_books;
        public List<ViewBook> all_books;
        private DGV_Visualisator dgv_Visualisator;
        public Form_Action()
        {
            InitializeComponent();
            this.dgv_Visualisator = new DGV_Visualisator();
            ComboBox_Helper.CB_reload<Place>(CB_Place);
            ComboBox_Helper.CB_reload<ActionType>(CB_Action_Type);

            all_books = Queries_from_Views.Get_Books();
            Assign_All_Books();
            dgv_Visualisator.Prepare_DGV_For_Type<ViewBook>(DGV_AllBooks);
            DGV_AllBooks.Refresh();

            action_books = new();
            Assign_Selected_Books();
            dgv_Visualisator.Prepare_DGV_For_Type<ViewBook>(DGV_ActionBooks);
            DGV_ActionBooks.Refresh();
        }
        public Form_Action(Action action, List<ViewBook> action_books) : this()
        {   
            this.action_books = action_books;
            Assign_Selected_Books();
            // loading remaining action content
            if (action.Place != null) CB_Place.SelectedValue = action.Place;
            if (action.ActionType != null) CB_Action_Type.SelectedValue = action.ActionType;
            if (action.Comment != null) TB_Comment.Text = action.Comment;
            if (action.Date is not null)
            {
                DateTime d = new DateTime(action.Date.Value.Year, action.Date.Value.Month, action.Date.Value.Day);
                dateTimePicker.Value = d;
            }
        }

        private void button_New_Book_Click(object sender, EventArgs e)
        {
            long book_id = Book.Create_Item();
            if (book_id > 0)
            {
                all_books = Queries_from_Views.Get_Books();
                Assign_All_Books();
                dgv_Visualisator.Prepare_DGV_For_Type<ViewBook>(DGV_AllBooks);

                General_Manipulations.Show_Row(DGV_AllBooks, book_id.ToString(), "Id");
            }
            DialogResult = DialogResult.None; // works?
        }

        private void button_Add_Book_to_Action_Click(object sender, EventArgs e)
        {
            int index = DGV_AllBooks.SelectedRows[0].Index;
            long id = (long)DGV_AllBooks.Rows[index].Cells["Id"].Value;
            var b = (from x in all_books
                     where x.Id == id
                     select x).ToList().First();
            if (b is not null && !action_books.Exists(e => e.Id == b.Id))
                action_books.Add(b);
            DGV_ActionBooks_Refresh();
        }

        private void DGV_ActionBooks_Refresh()
        {
            Assign_Selected_Books();
            DialogResult = DialogResult.None;
        }

        private void button_Del_Book_from_Action_Click(object sender, EventArgs e)
        {
            if (action_books != null && action_books.Count != 0)
            {
                int index = DGV_ActionBooks.SelectedRows[0].Index;
                long id = (long)DGV_ActionBooks.Rows[index].Cells["Id"].Value;
                var b = (from x in action_books
                         where x.Id == id
                         select x).ToList().First();

                if (b is not null && action_books.Exists(e => e.Id == b.Id))
                    action_books.Remove(b);
                DGV_ActionBooks_Refresh();
            }
        }

        private void DGV_AllBooks_DoubleClick(object sender, EventArgs e)
        {
            button_Add_Book_to_Action_Click(sender, e);
        }

        private void DGV_ActionBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button_Del_Book_from_Action_Click(sender, e);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (TB_Comment.Text == "")
            {
                General_Manipulations.Simple_Message(Localization.Substitute("No_action_notes_specified"));
                this.DialogResult = DialogResult.TryAgain;
            }
            else 
                if (action_books == null || action_books.Count < 1)
            {
                General_Manipulations.Simple_Message(Localization.Substitute("No_books_selected"));
                this.DialogResult = DialogResult.TryAgain;
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_Action_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.TryAgain)
                e.Cancel = true;
        }
        private void Assign_All_Books()
        {
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<ViewBook>(DGV_AllBooks, all_books);
        }
        private void Assign_Selected_Books()
        {
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<ViewBook>(DGV_ActionBooks, action_books);
        }
    }
}
