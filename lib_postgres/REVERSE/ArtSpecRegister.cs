using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ArtSpecRegister
    {
        public long Id { get; set; }
        public long? ArtId { get; set; }
        public long? SpecRegisterAttributeId { get; set; }
        public char? Comment { get; set; }
        public DateOnly? Date { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Art? Art { get; set; }
        public virtual SpecRegisterAttribute? SpecRegisterAttribute { get; set; }
    }
}
