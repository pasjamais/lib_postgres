using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ViewBook
    {
        public long? Id { get; set; }
        public string? Название { get; set; }
        public string? АвторЫ { get; set; }
        public decimal? ГодИздания { get; set; }
        public string? Жанр { get; set; }
        public string? Издательство { get; set; }
        public string? Шифр { get; set; }
    }
}
