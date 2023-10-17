using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class Place
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DGV.Columns[3].Visible = false;
            DGV.Columns[4].Visible = false;
            DGV.Columns[5].Visible = false;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
            DGV.Columns[1].HeaderText = Localization.Substitute("Storage");
            DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.45);
            DGV.Columns[2].HeaderText = Localization.Substitute("Comment");
            DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.45);
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static dynamic Prepare_View()
        {
            return DB_Agent.Get_Places();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Storages_list");
        }
    }
}
