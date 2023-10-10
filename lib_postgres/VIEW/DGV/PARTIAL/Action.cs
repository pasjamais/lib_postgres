using lib_postgres.LOCALIZATION;

namespace lib_postgres
{
    public partial class Action
    {
        public static void Prepare_DGV(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[5].Visible = false;
            dgv.Columns[0].HeaderText = "Id"; dgv.Columns[0].FillWeight = (int)(dgv.Width * 0.10);
            dgv.Columns[1].HeaderText = Localization.Substitute("Date"); dgv.Columns[1].FillWeight = (int)(dgv.Width * 0.10);
            dgv.Columns[2].HeaderText = Localization.Substitute("Action"); dgv.Columns[2].FillWeight = (int)(dgv.Width * 0.10);
            dgv.Columns[3].HeaderText = Localization.Substitute("Comment"); dgv.Columns[3].FillWeight = (int)(dgv.Width * 0.55);
            dgv.Columns[4].HeaderText = Localization.Substitute("Place"); dgv.Columns[4].FillWeight = (int)(dgv.Width * 0.15);
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
