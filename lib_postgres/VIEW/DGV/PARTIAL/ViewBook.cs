using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class ViewBook
    {
        public static void Prepare_DGV(DataGridView dgv)
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
    }
}
