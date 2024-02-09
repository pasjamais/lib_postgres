using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_postgres.CRUD;
using lib_postgres.FORMS;

namespace lib_postgres
{
    public partial class Bibliography : ICan_Create_Item, IHas_field_IsDeleted
    {
        static long Create_Item()
        {
            Form_Bibliography form_bibliography = new ();
            var DialogResult = form_bibliography.ShowDialog();
            if (DialogResult != DialogResult.OK) return -1;

            Bibliography element = DB_Agent.Get_First_Deleted_Entity_or_New<Bibliography>(DB_Agent.Get_bibliographies());

            return element.Id;

        }
    }
}
