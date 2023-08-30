using lib_postgres.CODE;
using lib_postgres.PARTIAL;
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
    public partial class Form_Action : Form
    {

        public List<ViewBook> action_books;
        public List<ViewBook> all_books;
        private DGV_Visualisator dgv_Visualisator;
        public Form_Action()
        {
            InitializeComponent();
            this.dgv_Visualisator = new DGV_Visualisator();
            General_Manipulations.CB_reload<Place>(CB_Place, 1);
            General_Manipulations.CB_reload<ActionType>(CB_Action_Type, 1);

            all_books = Queries_from_Views.Get_Books();
            DGV_AllBooks.DataSource = General_Manipulations.Bind_List_to_DGV(all_books);
            dgv_Visualisator.Prepare_DGV_For_Type<ViewBook>(DGV_AllBooks);
            DGV_AllBooks.Refresh();

            action_books = new();
            DGV_ActionBooks.DataSource = General_Manipulations.Bind_List_to_DGV(action_books);
            dgv_Visualisator.Prepare_DGV_For_Type<ViewBook>(DGV_ActionBooks);
            DGV_ActionBooks.Refresh();
        }


        private void button_New_Book_Click(object sender, EventArgs e)
        {
            long book_id = Book.Create_Item();
            if (book_id > 0)
            {
                all_books = Queries_from_Views.Get_Books();
                DGV_AllBooks.DataSource = General_Manipulations.Bind_List_to_DGV(all_books);
                dgv_Visualisator.Prepare_DGV_For_Type<ViewBook>(DGV_AllBooks);

                General_Manipulations.show_row(DGV_AllBooks, book_id.ToString(), "Id");
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
            DGV_AcrtionBooks_Refresh();
        }

        private void DGV_AcrtionBooks_Refresh()
        {
            BindingSource source = new BindingSource();
            source.DataSource = action_books;
            DGV_ActionBooks.DataSource = source;
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
                DGV_AcrtionBooks_Refresh();
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
    }
}
