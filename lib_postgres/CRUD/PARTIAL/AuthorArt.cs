using lib_postgres.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    public partial class AuthorArt : IHas_field_IsDeleted
    {
        public static bool Reset_Element_if_not_New(AuthorArt item)
        {
            bool is_new_element = (item.Id == 0) ? true : false;
            if (!is_new_element)
            {
                item.Art = null;
                item.Author = null;
            }
            return is_new_element;
        }

    }
}
