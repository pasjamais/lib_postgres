using lib_postgres.QUERIES;
using lib_postgres.VIEW.COMBOBOX;

namespace lib_postgres
{
    public partial class ViewBook : IShow_in_Combobox
    {
        public static void Show_in_Combobox(ComboBox CB)
        {
            var elements = Queries_LinQ.Get_Books_Short();
            long id = 0;
            if (elements != null && elements.Count > 0 && elements.First().Id != null)
            {
                    id =(long)elements.First().Id;
            }
            CB.DataSource = elements;
            ComboBox_Helper.CB_visual_reload(CB, id);
        }
    }
}
