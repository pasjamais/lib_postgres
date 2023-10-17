using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class Person
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].HeaderText = Localization.Substitute("Simple_proper_name");
            DGV.Columns[2].Visible = false;
            DGV.Columns[3].Visible = false;
            DGV.Columns[4].Visible = false;
            DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.15);
            DGV.Columns[1].FillWeight = (int)(DGV.Width * 0.85);
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static dynamic Prepare_View()
        {
            return DB_Agent.Get_Persons();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Persons_list");
        }
    }
}
