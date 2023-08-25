using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Author 
    {
        public Author()
        {
            ArtToReadSourceAuthors = new HashSet<ArtToRead>();
            ArtToReadToreadAuthors = new HashSet<ArtToRead>();
            AuthorArts = new HashSet<AuthorArt>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ArtToRead> ArtToReadSourceAuthors { get; set; }
        public virtual ICollection<ArtToRead> ArtToReadToreadAuthors { get; set; }
        public virtual ICollection<AuthorArt> AuthorArts { get; set; }
    }
}
