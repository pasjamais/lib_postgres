using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class SourceToreadAnother
    {
        public SourceToreadAnother()
        {
            ArtToReads = new HashSet<ArtToRead>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ArtToRead> ArtToReads { get; set; }
    }
}
