using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ViewAction
    {
        public long? ActionId { get; set; }
        public DateOnly? Date { get; set; }
        public string? Comment { get; set; }
        public string? Place { get; set; }
    }
}
