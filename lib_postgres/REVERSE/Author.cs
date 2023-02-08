using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Author
    {
        public Author()
        {
            AuthorArts = new HashSet<AuthorArt>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<AuthorArt> AuthorArts { get; set; }
    }
}
