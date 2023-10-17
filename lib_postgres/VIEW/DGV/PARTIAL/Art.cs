using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;

namespace lib_postgres
{
    public partial class Art
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].HeaderText = Localization.Substitute("Art");
            DGV.Columns[2].HeaderText = Localization.Substitute("Author_s");
            DGV.Columns[3].HeaderText = Localization.Substitute("Genre");
            DGV.Columns[5].HeaderText = Localization.Substitute("Writing_year");
            DGV.Columns[4].HeaderText = Localization.Substitute("Langue_original");
            DGV.Columns[5].Visible = false;
            DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
            DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.35);
            DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.20);
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static dynamic Prepare_View()
        {
            return Queries_LinQ.Get_Arts();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Art_list");
        }
    }
}
