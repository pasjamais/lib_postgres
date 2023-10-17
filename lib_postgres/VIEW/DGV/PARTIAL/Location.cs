using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;

namespace lib_postgres
{
    public partial class Location
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].HeaderText = Localization.Substitute("Date");
            DGV.Columns[2].HeaderText = Localization.Substitute("Action");
            DGV.Columns[3].HeaderText = Localization.Substitute("Notice");
            DGV.Columns[4].HeaderText = Localization.Substitute("Appellation");
            DGV.Columns[5].HeaderText = Localization.Substitute("Author_s");
            DGV.Columns[6].HeaderText = Localization.Substitute("Genre");
            DGV.Columns[7].HeaderText = Localization.Substitute("Publication_year");
            DGV.Columns[8].HeaderText = Localization.Substitute("Code");
            DGV.Columns[9].HeaderText = Localization.Substitute("ID_book_short_text");
            DGV.Columns[10].HeaderText = Localization.Substitute("Placement");
            DGV.Columns[0].FillWeight = 10;
            DGV.Columns[1].FillWeight = 20;
            DGV.Columns[2].FillWeight = 27;
            DGV.Columns[3].FillWeight = 30;
            //   DGV.Columns[4].FillWeight = 20;
            //   DGV.Columns[5].FillWeight = 20;
            DGV.Columns[6].FillWeight = 10;
            DGV.Columns[7].FillWeight = 8;
            DGV.Columns[8].FillWeight = 10;
            DGV.Columns[9].FillWeight = 10;
            DGV.Columns[10].FillWeight = 25;
        }
        public static List<Location_Record> Prepare_View()
        {
            return Queries_LinQ.Get_Locations();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Placements_list");
        }
    }
}
