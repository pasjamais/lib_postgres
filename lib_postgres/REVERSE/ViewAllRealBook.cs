using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ViewAllRealBook
    {
        public long? UniqueBookId { get; set; }
        public string? Место { get; set; }
        public string? Движ { get; set; }
        public string? Действие { get; set; }
        public DateOnly? Дата { get; set; }
        public string? Название { get; set; }
        public string? АвторЫ { get; set; }
        public string? Жанр { get; set; }
        public string? ЯзыкНаписания { get; set; }
        public string? ЯзыкИздания { get; set; }
        public decimal? ГодИздания { get; set; }
        public string? Издательство { get; set; }
        public string? Шифр { get; set; }
        public int? Страниц { get; set; }
    }
}
