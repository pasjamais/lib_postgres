using lib_postgres.CRUD;
using lib_postgres.LOCALIZATION;
using static lib_postgres.VIEW.SPEC_ENTITIES_VIEWS.Structures;

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
        public static List<View_Action> Prepare_View()
        {
            var actions = DB_Agent.Get_Actions();
            var places = DB_Agent.Get_Places();
            var act_types = DB_Agent.Get_ActionTypes();
            var result = (from a in actions
                          join p in places on a.Place equals p.Id into left_places
                          from left_p in left_places.DefaultIfEmpty()
                          join t in act_types on a.ActionType equals t.Id into left_act_types
                          from left_t in left_act_types.DefaultIfEmpty()
                          select new View_Action
                          {
                              Id = a.Id,
                              Date = a.Date,
                              ActionType = left_t == null ? "" : left_t.Name,
                              Comment = a.Comment == null ? "" : a.Comment,
                              Place = left_p == null ? "" : left_p.Name,
                              Name = a.Name == null ? "" : a.Name
                          }).ToList();
            return result;
        }
        public static string Get_Caption()
        {
           return Localization.Substitute("Action_list");
        }
    }
}
