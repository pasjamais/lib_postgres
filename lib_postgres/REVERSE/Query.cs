using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Query
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
