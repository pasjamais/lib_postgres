using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_postgres.CRUD;
using lib_postgres.FORMS;
using Microsoft.EntityFrameworkCore.Storage;

namespace lib_postgres
{
    public partial class Art : IHas_field_IsDeleted
    {
        public static List<lib_postgres.Art> Get_Deleted_Arts()
        {
            List<lib_postgres.Art> arts = DB_Agent.Get_Arts();
            List<lib_postgres.Art> deleted_arts = (from art in arts
                                                   where art.IsDeleted is true
                                                   select art).ToList();
            return deleted_arts;
        }

        public static List<long> Get_Deleted_Items_IDs()
        {
            List<lib_postgres.Art> deleted_arts = Get_Deleted_Arts();
            List<long> del_arts_id = (from art in deleted_arts
                                      select art.Id).ToList();
            return del_arts_id;
        }
    }
}
