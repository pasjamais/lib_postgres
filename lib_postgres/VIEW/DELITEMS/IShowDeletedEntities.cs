using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VIEW.DELITEMS
{
    public interface IShowDeletedEntities
    {
        void Execute(List<long> deleted_IDs, DataGridView DGV);
    }
}
