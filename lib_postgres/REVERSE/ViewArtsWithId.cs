using System;
using System.Collections.Generic;


namespace lib_postgres
{
    public partial class ViewArtsWithId
    {
        public long? Id { get; set; }
        public string? Название { get; set; }
        public string? АвторЫ { get; set; }
        public string? Жанр { get; set; }
    }
}
