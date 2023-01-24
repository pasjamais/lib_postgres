using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Series
    {
        public Series()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
