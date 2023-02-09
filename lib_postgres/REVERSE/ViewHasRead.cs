using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ViewHasRead
    {
        public long? Id { get; set; }
        public DateOnly? Дата { get; set; }
        public string? АвторЫ { get; set; }
        public string? Название { get; set; }
        public string? Жанр { get; set; }
        public string? ЯзыкОригинала { get; set; }
        public string? Впечатление { get; set; }
        public string? Оценка { get; set; }
        public string? Формат { get; set; }
    }
}
