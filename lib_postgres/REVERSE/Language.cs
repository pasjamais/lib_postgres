using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Language
    {
        public Language()
        {
            Arts = new HashSet<Art>();
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Bref { get; set; }

        public virtual ICollection<Art> Arts { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
