using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Mark
    {
        public Mark()
        {
            ArtReads = new HashSet<ArtRead>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ArtRead> ArtReads { get; set; }
    }
}
