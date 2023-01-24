using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Art
    {
        public Art()
        {
            AuthorArts = new HashSet<AuthorArt>();
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? Genre { get; set; }
        public DateOnly? WritingYear { get; set; }
        public long? OrigLanguage { get; set; }

        public virtual Genre? GenreNavigation { get; set; }
        public virtual Language? OrigLanguageNavigation { get; set; }
        public virtual ICollection<AuthorArt> AuthorArts { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
