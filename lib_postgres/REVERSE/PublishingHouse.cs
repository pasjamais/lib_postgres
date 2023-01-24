using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class PublishingHouse
    {
        public PublishingHouse()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
