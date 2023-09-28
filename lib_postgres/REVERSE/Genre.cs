using lib_postgres.CRUD;
using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Genre 
    {
        public Genre()
        {
            Arts = new HashSet<Art>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Art> Arts { get; set; }
    }
}
