using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class City
    {
        public City()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
