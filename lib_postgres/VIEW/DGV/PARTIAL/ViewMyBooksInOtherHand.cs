using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;

namespace lib_postgres
{
    public partial class ViewMyBooksInOtherHand
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].Visible = false;//Place
            DGV.Columns[2].HeaderText = Localization.Substitute("Notice");
            DGV.Columns[3].HeaderText = Localization.Substitute("Action");
            DGV.Columns[4].HeaderText = Localization.Substitute("Date");
            DGV.Columns[5].HeaderText = Localization.Substitute("Appellation");
            DGV.Columns[6].HeaderText = Localization.Substitute("Author_s");
            for (int i = 7; i <= 14; i++) { DGV.Columns[i].Visible = false; }
            DGV.Columns[0].FillWeight = (int)(DGV.Width * 0.05);
            DGV.Columns[2].FillWeight = (int)(DGV.Width * 0.25);
            DGV.Columns[3].FillWeight = (int)(DGV.Width * 0.05);
            DGV.Columns[4].FillWeight = (int)(DGV.Width * 0.05);
            DGV.Columns[5].FillWeight = (int)(DGV.Width * 0.25);
            DGV.Columns[6].FillWeight = (int)(DGV.Width * 0.3);
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Books_list_taken_by_others");
        }
        public static List<ViewMyBooksInOtherHand> Prepare_View()
        {
            return Queries_from_Views.Get_My_Books_in_Other_Hands();
        }
    }
}
