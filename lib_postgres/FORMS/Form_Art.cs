using lib_postgres.VIEW;
using lib_postgres.VIEW.COMBOBOX;
using lib_postgres.LOCALIZATION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using lib_postgres.CRUD;

namespace lib_postgres
{
    public partial class Form_Art : Form
    {
        public List<Author>? selected_Autors;
        private DGV_Visualisator dgv_Visualisator;
        public Form_Art()
        {
            InitializeComponent();
            this.dgv_Visualisator = new DGV_Visualisator();
            ComboBox_Helper.CB_reload<Language>(CB_Langue); // here possible show language by default
            ComboBox_Helper.CB_reload<Genre>(CB_Genre);
            selected_Autors = new List<Author>();
            Assign_All_Authors();
            Assign_Selected_Authors();

            dgv_Visualisator.Prepare_DGV_For_Type<Author>(DGV_All_Authors);
            dgv_Visualisator.Prepare_DGV_For_Type<Author>(DGV_Selected_Authors);
            DGV_Selected_Authors.Refresh();
            DGV_All_Authors.Refresh();
        }

        public Form_Art(List<Author>? authors) : this() // for ToolStripMenuItem_Arts_Edit_Click
        {
            selected_Autors = authors;
            Assign_Selected_Authors();
            DGV_Selected_Authors.Refresh();
        }

        private void BT_Add_Langue_Original_Click(object sender, EventArgs e)
        {
            Create_Language();
        }

        private void BT_Add_Genre_Click(object sender, EventArgs e)
        {
            Create_Genre();
        }

        private void BT_Select_Author_Click(object sender, EventArgs e)
        {
            Select_Author_for_Art();
        }

        private void BT_Add_Author_Click(object sender, EventArgs e)
        {
            Create_Author();
        }

        private void BT_Deselect_Author_Click(object sender, EventArgs e)
        {
            Remove_Author_from_Art();
        }

        private void DGV_Selected_Authors_DoubleClick(object sender, EventArgs e)
        {
            Remove_Author_from_Art();
        }

        private void DGV_All_Authors_DoubleClick(object sender, EventArgs e)
        {
            Select_Author_for_Art();
        }

        private void DGV_Selected_Authors_Refresh()
        {
            Assign_Selected_Authors();
            DialogResult = DialogResult.None;
        }

        private void Select_Author_for_Art()
        {
            int index = DGV_All_Authors.SelectedRows[0].Index;
            int idAuthor = int.Parse(DGV_All_Authors[0, index].Value.ToString());
            Author author = DB_Agent.Get_Author((long)idAuthor);
                if (author != null && selected_Autors != null)
                {
                    if (!selected_Autors.Exists(e => e.Id == author.Id))
                        selected_Autors.Add(author);
                }
            DGV_Selected_Authors_Refresh();
        }
        private void Remove_Author_from_Art()
        {
            if (selected_Autors != null && selected_Autors.Count != 0)
            {
                int index = DGV_Selected_Authors.SelectedRows[0].Index;
                int idAuthor = int.Parse(DGV_Selected_Authors[0, index].Value.ToString());
                Author author = DB_Agent.Get_Author(idAuthor);
                if (selected_Autors.Exists(e => e.Id == author.Id))
                {
                    selected_Autors.RemoveAt(index);
                }
                Assign_Selected_Authors();
                DialogResult = DialogResult.None;
            }
        }
        private void Create_Author()
        {
            var id = Author.Create_Item();
            if (id > 0)
            {
                Assign_All_Authors();
                dgv_Visualisator.Prepare_DGV_For_Type<Author>(DGV_All_Authors);
                General_Manipulations.show_row(DGV_All_Authors, id.ToString(), "Id");
            }
            DialogResult = DialogResult.None;
        }

        private void Create_Genre()
        {
            var id = Genre.Create_Item();
            if (id > 0) ComboBox_Helper.CB_reload<Genre>(CB_Genre, id);
            DialogResult = DialogResult.None;
        }

        private void Create_Language()
        {
            var id = Language.Create_Item();
            if (id != 0) ComboBox_Helper.CB_reload<Language>(CB_Langue, id);
            DialogResult = DialogResult.None;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (tb_Name.Text == "")
            {
                General_Manipulations.simple_message(Localization.Substitute("No_title_specified"));
                this.DialogResult = DialogResult.TryAgain;
            }
            else
               if ((selected_Autors == null) || (selected_Autors.Count == 0))
            {
                General_Manipulations.simple_message(Localization.Substitute("No_author_selected"));
                this.DialogResult = DialogResult.TryAgain;
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_Art_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.TryAgain)
                e.Cancel = true;
        }

        private void TB_YearCreation_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void ChB_Language_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = CB_Langue.Enabled = ChB_Language.Checked;
        }

        private void ChB_Genre_CheckedChanged(object sender, EventArgs e)
        {
            label2.Enabled = CB_Genre.Enabled = ChB_Genre.Checked;
        }
        private void Assign_All_Authors()
        {
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<Author>(DGV_All_Authors, DB_Agent.Get_Authors());
        }
        private void Assign_Selected_Authors()
        {
            dgv_Visualisator.Assign_SortableBindingList_to_DGV<Author>(DGV_Selected_Authors, selected_Autors);
        }
    }
}