using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Art
    {
        public Art()
        {
            ArtReads = new HashSet<ArtRead>();
            ArtSpecRegisters = new HashSet<ArtSpecRegister>();
            ArtToReadSourceArts = new HashSet<ArtToRead>();
            ArtToReadToreadArts = new HashSet<ArtToRead>();
            AuthorArts = new HashSet<AuthorArt>();
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? Genre { get; set; }
        public DateOnly? WritingYear { get; set; }
        public long? OrigLanguage { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Genre? GenreNavigation { get; set; }
        public virtual Language? OrigLanguageNavigation { get; set; }
        public virtual ICollection<ArtRead> ArtReads { get; set; }
        public virtual ICollection<ArtSpecRegister> ArtSpecRegisters { get; set; }
        public virtual ICollection<ArtToRead> ArtToReadSourceArts { get; set; }
        public virtual ICollection<ArtToRead> ArtToReadToreadArts { get; set; }
        public virtual ICollection<AuthorArt> AuthorArts { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
