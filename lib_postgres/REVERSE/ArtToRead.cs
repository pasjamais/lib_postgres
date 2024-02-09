using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ArtToRead
    {
        public long Id { get; set; }
        public DateOnly? Date { get; set; }
        public long? SourceArtId { get; set; }
        public long? SourceAuthorId { get; set; }
        public long? SourceAnotherId { get; set; }
        public long? ToreadArtId { get; set; }
        public long? ToreadAuthorId { get; set; }
        public string? Comment { get; set; }
        public bool? IsDeleted { get; set; }
        public long? IdBiblopgraphy { get; set; }

        public virtual Bibliography? IdBiblopgraphyNavigation { get; set; }
        public virtual SourceToreadAnother? SourceAnother { get; set; }
        public virtual Art? SourceArt { get; set; }
        public virtual Author? SourceAuthor { get; set; }
        public virtual Art? ToreadArt { get; set; }
        public virtual Author? ToreadAuthor { get; set; }
    }
}
