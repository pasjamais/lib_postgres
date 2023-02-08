using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class BookFormat
    {
        public BookFormat()
        {
            ArtReads = new HashSet<ArtRead>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ArtRead> ArtReads { get; set; }
    }
}
