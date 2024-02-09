using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Bibliography
    {
        public Bibliography()
        {
            ArtToReads = new HashSet<ArtToRead>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public string? Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ArtToRead> ArtToReads { get; set; }
    }
}
