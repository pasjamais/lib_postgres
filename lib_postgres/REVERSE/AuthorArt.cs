using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class AuthorArt
    {
        public long Id { get; set; }
        public long Author { get; set; }
        public long Art { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Art ArtNavigation { get; set; } = null!;
        public virtual Author AuthorNavigation { get; set; } = null!;
    }
}
