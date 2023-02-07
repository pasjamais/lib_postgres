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
            General_Manipulations.CB_reload<Language>(CB_Langue, 3);//русский по-умолчанию
            CB_Genre_reload(1);
            selected_Autors = new List<Author>();
            DGV_All_Authors.DataSource      = General_Manipulations.Bind_List_to_DGV(DB_Agent.Get_Authors());
            DGV_Selected_Authors.DataSource = General_Manipulations.Bind_List_to_DGV(selected_Autors);
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Author>(DGV_All_Authors);
            CODE.Form_Element_DGV.Prepare_DGV_For_Type<Author>(DGV_Selected_Authors);
            DGV_Selected_Authors.Refresh();
            DGV_All_Authors.Refresh();
        }

        public Form_Art(List<Author>? authors) : this() // for ToolStripMenuItem_Arts_Edit_Click
        {
            selected_Autors = authors;
            DGV_Selected_Authors.DataSource = General_Manipulations.Bind_List_to_DGV(selected_Autors);
            DGV_Selected_Authors.Refresh();
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
            var id = PARTIAL.Language.Add_Language();
            if (id != 0) General_Manipulations.CB_reload<Language>(CB_Langue, id);
            DialogResult = DialogResult.None;
        }

        private void BT_Add_Genre_Click(object sender, EventArgs e)
        {
            var id = PARTIAL.Genre.Add_Genre();
            if (id > 0) CB_Genre_reload(id);
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
            var id = PARTIAL.Author.Add_Author();
            if (id > 0)
            {
                DGV_All_Authors.DataSource = DB_Agent.Get_Authors();
                CODE.Form_Element_DGV.Prepare_DGV_For_Type<Author>(DGV_All_Authors);
                General_Manipulations.show_row(DGV_All_Authors, id.ToString(), "Id");
            }
            DialogResult = DialogResult.None;
        }


        private void BT_Deselect_Author_Click(object sender, EventArgs e)
        {
            if (selected_Autors != null && selected_Autors.Count != 0)
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

        }

        private void DGV_Selected_Authors_Refresh()
        {
            BindingSource source = new BindingSource();
            source.DataSource = selected_Autors;
            DGV_Selected_Authors.DataSource = source;
            DialogResult = DialogResult.None;
        }
         
        private void DGV_Selected_Authors_DoubleClick(object sender, EventArgs e)
        {
            BT_Deselect_Author_Click(sender, e);
        }

        private void DGV_All_Authors_DoubleClick(object sender, EventArgs e)
        {
            BT_Select_Author_Click(sender, e);
        }
    }
}