using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class SpecRegisterAttribute
    {
        public SpecRegisterAttribute()
        {
            ArtSpecRegisters = new HashSet<ArtSpecRegister>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ArtSpecRegister> ArtSpecRegisters { get; set; }
    }
}
