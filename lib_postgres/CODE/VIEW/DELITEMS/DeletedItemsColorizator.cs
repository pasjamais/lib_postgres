using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE.VIEW.DELITEMS
{
    public class DeletedItemsColorizator : IShowDeletedEntities
    {
        public void Execute(List<long> deleted_IDs, DataGridView DGV)
        {
            Colorize_Deleted_Entities_Rows(deleted_IDs, DGV);
        }
        private void Colorize_Deleted_Entities_Rows(List<long> deleted_IDs, DataGridView DGV)
        {
            foreach (DataGridViewRow this_row in DGV.Rows)
            {
                if (deleted_IDs.Contains((long)this_row.Cells["Id"].Value))
                    this_row.DefaultCellStyle.BackColor = Color.IndianRed;
            }
        }
    }
}
