using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_postgres.VISUAL.GraphViz
{
    public class CB_data_adapter
    {
        public void CB_preparation(ComboBox cb, object datasource)
        {
            cb.DataSource = datasource;
            cb.ValueMember = "Id";
            cb.DisplayMember = "Name";
            cb.SelectedIndex = 1;
        }
    }
}
