using System;
using System.Collections.Generic;


namespace lib_postgres
{
    public partial class ViewHintArtToAuthor
    {
        public long? Id { get; set; }
        public string? ИсточникКнига { get; set; }
        public string? ИсточникАвтор { get; set; }
        public string? РекомендацияАвтор { get; set; }
        public string? Comment { get; set; }
    }
}
