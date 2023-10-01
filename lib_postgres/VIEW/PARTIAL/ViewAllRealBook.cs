using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    partial class ViewAllRealBook
    {
        // Added for correctly working
        // Form_Main.Cmi_item_find_book_Click correctly working
        public long Id
        {
            get => this.UniqueBookId ?? 0;
        }
    }
}

