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
    public partial class Form_Art : Form
    {
        public List<Author>? selected_Autors;
        public Form_Art()
        {
            InitializeComponent();
            CB_Langue_reload(3);
            CB_Genre_reload(1);
            selected_Autors = new List<Author>();
            DGV_All_Authors.DataSource = General_Manipulations.Bind_List_to_DGV(DB_Agent.Get_Authors());
            DGV_All_Authors.Refresh();
            DGV_Selected_Authors.DataSource = General_Manipulations.Bind_List_to_DGV(selected_Autors);
            DGV_Selected_Authors.Refresh();
        }

        public Form_Art(List<Author>? authors) : this() // for ToolStripMenuItem_Arts_Edit_Click
        {
            selected_Autors = authors;
            DGV_Selected_Authors.DataSource = General_Manipulations.Bind_List_to_DGV(selected_Autors);
            DGV_Selected_Authors.Refresh();
        }


        private void CB_Langue_reload(long id)
        {
            var languages = DB_Agent.Get_Languages();
            var item = (from q in languages
                        where q.Id == id
                        select q).Take(1).First();
            CB_Langue.DataSource = languages;
            CB_Langue.ValueMember = "Id";
            CB_Langue.DisplayMember = "Name";
            CB_Langue.SelectedIndex = languages.IndexOf(item);
        }


        private void CB_Genre_reload(long id)
        {
            var genres = DB_Agent.Get_Genres();
            var item = (from q in genres
                        where q.Id == id
                        select q).Take(1).First();
            CB_Genre.DataSource = genres;
            CB_Genre.ValueMember = "Id";
            CB_Genre.DisplayMember = "Name";
            CB_Genre.SelectedIndex = genres.IndexOf(item);
        }

        private void BT_Add_Langue_Original_Click(object sender, EventArgs e)
        {
            var id = General_Manipulations.Add_Language();
            CB_Langue_reload(id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_Genre_Click(object sender, EventArgs e)
        {
            var id = General_Manipulations.Add_Genre();
            CB_Genre_reload(id);
            DialogResult = DialogResult.None;
        }

        private void BT_Select_Author_Click(object sender, EventArgs e)
        {
            int index = DGV_All_Authors.SelectedRows[0].Index;
            int idAuthor = int.Parse(DGV_All_Authors[0, index].Value.ToString());
            using (libContext db = new libContext())
            {
                Author author = db.Authors.Find((long)idAuthor);
                if (!selected_Autors.Exists(e => e.Name == author.Name))
                    selected_Autors.Add(author);
            }
            DGV_Selected_Authors_Refresh();
        }

        private void BT_Add_Author_Click(object sender, EventArgs e)
        {
            General_Manipulations.Add_Author(DGV_All_Authors);
            DialogResult = DialogResult.None;
        }


        private void BT_Deselect_Author_Click(object sender, EventArgs e)
        {
            int index = DGV_Selected_Authors.SelectedRows[0].Index;
            int idAuthor = int.Parse(DGV_Selected_Authors[0, index].Value.ToString());
            Author author = DB_Agent.Get_Author(idAuthor);
            if (selected_Autors.Exists(e => e.Name == author.Name))
            {
                selected_Autors.RemoveAt(index);
            }
            DGV_Selected_Authors.DataSource = General_Manipulations.Bind_List_to_DGV(selected_Autors);
            DialogResult = DialogResult.None;

            
        }

        private void DGV_Selected_Authors_Refresh()
        {
            BindingSource source = new BindingSource();
            source.DataSource = selected_Autors;
            DGV_Selected_Authors.DataSource = source;
            DialogResult = DialogResult.None;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DGV_Selected_Authors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {

        }
    }
}