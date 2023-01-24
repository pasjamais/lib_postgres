using System;
using System.Collections.Generic;
using System.Collections;

namespace lib_postgres
{
    public partial class ChifresName
    {
        public long Id { get; set; }
        public long IdGenre { get; set; }
        public BitArray? Chifre { get; set; }
    }
}
