using System;
using System.Collections.Generic;


namespace lib_postgres
{
    public partial class ViewHintFromAuthor
    {
        public long? Id { get; set; }
        public string? ИсточникАвтор { get; set; }
        public string? РекомендацияАвтор { get; set; }
        public string? РекомендацияКнига { get; set; }
        public string? РекомендацияАвторКниги { get; set; }
        public string? Comment { get; set; }
    }
}
