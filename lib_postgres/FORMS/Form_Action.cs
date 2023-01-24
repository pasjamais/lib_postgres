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
        public List<Book>? action_books;
        public Form_Action()
        {
            InitializeComponent();
            CB_Place_reload(1);
            CB_Action_Type_reload(1);
            action_books = new List<Book>();
            DGV_AllBooks.DataSource = General_Manipulations.Bind_List_to_DGV(DB_Agent.Get_Books());
            DGV_AllBooks.Refresh();
            DGV_AcrtionBooks.DataSource = General_Manipulations.Bind_List_to_DGV(action_books);
            DGV_AcrtionBooks.Refresh();
        }

        private void Form_Action_Load(object sender, EventArgs e)
        {

        }

        private void button_New_Book_Click(object sender, EventArgs e)
        {
            long book_id = General_Manipulations.Add_Book();
            if (book_id != -1)
            {
                DGV_AllBooks.DataSource = DB_Agent.Get_Books();
                DGV_AllBooks.Refresh();
                General_Manipulations.show_row(DGV_AllBooks, book_id.ToString(), "Id");
            }
            DialogResult = DialogResult.None; // works?
        }

        private void button_Add_Book_to_Action_Click(object sender, EventArgs e)
        {
            int index = DGV_AllBooks.SelectedRows[0].Index;
            int idBook = int.Parse(DGV_AllBooks[0, index].Value.ToString());
            using (libContext db = new libContext())
            {
                Book book = db.Books.Find((long)idBook);
                if (!action_books.Exists(e => e.Id == book.Id))
                    action_books.Add(book);
            }
            DGV_AcrtionBooks_Refresh();
        }

        private void DGV_AcrtionBooks_Refresh()
        {
            BindingSource source = new BindingSource();
            source.DataSource = action_books;
            DGV_AcrtionBooks.DataSource = source;
            DialogResult = DialogResult.None;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void CB_Place_reload(long id)
        {
            var places = DB_Agent.Get_Places();
            var item = (from q in places
                        where q.Id == id
                        select q).Take(1).First();
            CB_Place.DataSource = places;
            CB_Place.ValueMember = "Id";
            CB_Place.DisplayMember = "Name";
            CB_Place.SelectedIndex = places.IndexOf(item);
        }

        private void CB_Action_Type_reload(long id)
        {
            var action_types = DB_Agent.Get_ActionTypes();
            var item = (from q in action_types
                        where q.Id == id
                        select q).Take(1).First();
            CB_Action_Type.DataSource = action_types;
            CB_Action_Type.ValueMember = "Id";
            CB_Action_Type.DisplayMember = "Name";
            CB_Action_Type.SelectedIndex = action_types.IndexOf(item);
        }
    }
}
