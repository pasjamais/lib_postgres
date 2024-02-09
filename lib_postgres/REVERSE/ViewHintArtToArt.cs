using System;
using System.Collections.Generic;


namespace lib_postgres
{
    public partial class ViewHintArtToArt
    {
        public long? Id { get; set; }
        public string? ИсточникКнига { get; set; }
        public string? ИсточникАвтор { get; set; }
        public string? РекомендацияКнига { get; set; }
        public string? РекомендацияАвтор { get; set; }
        public string? Comment { get; set; }
    }
}
