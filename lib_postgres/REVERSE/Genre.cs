using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Genre : CODE.CRUD.IHas_field_IsDeleted, CODE.CRUD.IHas_field_ID
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
