using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using lib_postgres.QUERIES;

namespace lib_postgres
{
    public partial class ArtToRead
    {
        public static void Prepare_DGV(DataGridView DGV)
        {
            DGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[0].HeaderText = "Id";
            DGV.Columns[1].HeaderText = Localization.Substitute("Date");
            DGV.Columns[2].HeaderText = Localization.Substitute("Source_type");
            DGV.Columns[3].HeaderText = Localization.Substitute("Source");
            DGV.Columns[4].HeaderText = Localization.Substitute("Recommendation_type");
            DGV.Columns[5].HeaderText = Localization.Substitute("Recommendation");
            DGV.Columns[6].HeaderText = Localization.Substitute("Comment");
            for (int i = 7; i <= 11; i++) { DGV.Columns[i].Visible = false; }
            DGV.Columns[0].FillWeight = 20;
            DGV.Columns[1].FillWeight = 20;
            DGV.Columns[2].FillWeight = 20;
            DGV.Columns[4].FillWeight = 20;
        }
        public static dynamic Prepare_View()
        {
            return Queries_LinQ.Get_All_Recommendations();
        }
        public static string Get_Caption()
        {
            return Localization.Substitute("Recommendations_list");
        }
        private static void Colorise_DGV(DataGridView DGV)
        {
            List<long> arts_read_IDs = Art.Get_HaveRead_Items_IDs();
            foreach (DataGridViewRow this_row in DGV.Rows)
            {
                if ((this_row.Cells["ToreadArtId"].Value) is not null )
                    if (arts_read_IDs.Contains((long)this_row.Cells["ToreadArtId"].Value))
                        this_row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9ab973");
            }

        }
        public static void Highlighting(DataGridView DGV)
        {
            Colorise_DGV(DGV);
        }
       
    }
}
