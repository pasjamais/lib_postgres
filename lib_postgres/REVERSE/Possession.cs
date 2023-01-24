using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Possession
    {
        public long Id { get; set; }
        public DateOnly? Date { get; set; }
        public string? Comment { get; set; }
        public long Book { get; set; }
        public long? Person { get; set; }
        public long? Action { get; set; }

        public virtual Action? ActionNavigation { get; set; }
        public virtual Book BookNavigation { get; set; } = null!;
        public virtual Person? PersonNavigation { get; set; }
    }
}
