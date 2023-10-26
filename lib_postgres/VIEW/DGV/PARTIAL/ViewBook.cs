using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;

namespace lib_postgres
{
    public partial class ViewBook
    {
        public static void Prepare_DGV_Detailed(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[0].HeaderText = "Id";
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].HeaderText = Localization.Substitute("Notice");
            dgv.Columns[3].HeaderText = Localization.Substitute("Action");
            dgv.Columns[4].HeaderText = Localization.Substitute("Date");
            dgv.Columns[5].HeaderText = Localization.Substitute("Appellation");
            dgv.Columns[6].HeaderText = Localization.Substitute("Author_s");
            dgv.Columns[7].HeaderText = Localization.Substitute("Genre");
            dgv.Columns[8].HeaderText = Localization.Substitute("Langue_original");
            dgv.Columns[9].HeaderText = Localization.Substitute("Language_pub");
            dgv.Columns[10].HeaderText = Localization.Substitute("Publication_year");
            dgv.Columns[11].HeaderText = Localization.Substitute("Pubhouse");
            dgv.Columns[12].HeaderText = Localization.Substitute("Code");
            dgv.Columns[13].HeaderText = Localization.Substitute("Pages");
        }
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[0].HeaderText = "Id"; DGV.Columns[0].FillWeight = 10;
            DGV.Columns[1].HeaderText = Localization.Substitute("Appellation");
            DGV.Columns[2].HeaderText = Localization.Substitute("Author_s");
            DGV.Columns[3].HeaderText = Localization.Substitute("Publication_year"); DGV.Columns[3].FillWeight = 20;
            DGV.Columns[4].HeaderText = Localization.Substitute("Genre"); DGV.Columns[4].FillWeight = 40;
            DGV.Columns[5].HeaderText = Localization.Substitute("Pubhouse"); DGV.Columns[5].FillWeight = 25;
            DGV.Columns[6].HeaderText = Localization.Substitute("Code"); DGV.Columns[6].FillWeight = 10;
        }
        public static dynamic Prepare_View()
        {
            return Queries_from_Views.Get_Books();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Books_list");
        }
        private static void Colorise_DGV(DataGridView DGV)
        {
            List<long?> books_read_IDs = Get_HaveRead_Items_IDs();
            foreach (DataGridViewRow this_row in DGV.Rows)
            {
                if (books_read_IDs.Contains((long)this_row.Cells["Id"].Value))
                    this_row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9ab973");
            }
        }
        public static void Highlighting(DataGridView DGV)
        {
            Colorise_DGV(DGV);
        }
    }
}
