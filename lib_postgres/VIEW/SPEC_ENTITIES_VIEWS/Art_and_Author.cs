using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VIEW.SPEC_ENTITIES_VIEWS
{
    public class Art_and_Author
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Authors { get; set; }
        public string? Genre { get; set; }
        public string? OrigLanguage { get; set; }
        public string? WritingYear { get; set; }
    }
}
