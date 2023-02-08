using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Location
    {
        public long Id { get; set; }
        public bool? Operation { get; set; }
        public long? Book { get; set; }
        public long? Place { get; set; }
        public long? Owner { get; set; }
        public string? Comment { get; set; }
        public long? Action { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Action? ActionNavigation { get; set; }
        public virtual Book? BookNavigation { get; set; }
        public virtual Person? OwnerNavigation { get; set; }
        public virtual Place? PlaceNavigation { get; set; }
    }
}
