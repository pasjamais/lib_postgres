using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ArtRead
    {
        public long Id { get; set; }
        public long ArtId { get; set; }
        public DateOnly? Date { get; set; }
        public string? Comment { get; set; }
        public long? BookId { get; set; }
        public long? MarkId { get; set; }
        public long? BookFormatId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Art Art { get; set; } = null!;
        public virtual Book? Book { get; set; }
        public virtual BookFormat? BookFormat { get; set; }
        public virtual Mark? Mark { get; set; }
    }
}
