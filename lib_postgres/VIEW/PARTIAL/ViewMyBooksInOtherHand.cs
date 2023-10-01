using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres
{
    partial class ViewMyBooksInOtherHand
    {        
        // Added for correctly working menu commands for this typw of view of entity "Book"
        // and Form_Main.Cmi_item_find_book_Click correctly working
        public long Id
        {
            get => this.UniqueBookId ?? 0;
        }
    }
}
