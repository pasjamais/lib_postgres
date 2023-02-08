using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Book
    {
        public Book()
        {
            ArtReads = new HashSet<ArtRead>();
            Locations = new HashSet<Location>();
            Possessions = new HashSet<Possession>();
        }

        public long Id { get; set; }
        public long IdArt { get; set; }
        public DateOnly? PublicationYear { get; set; }
        public long? IdPublishingHouse { get; set; }
        public long? IdLanguage { get; set; }
        public long? IdCity { get; set; }
        public int? Pages { get; set; }
        public long? IdSeries { get; set; }
        public string? Code { get; set; }
        public bool? HasJacket { get; set; }
        public string? Comment { get; set; }
        public string? Notes { get; set; }
        public int? State { get; set; }
        public string? FamilyNotes { get; set; }
        public bool? IsArtBook { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Art IdArtNavigation { get; set; } = null!;
        public virtual City? IdCityNavigation { get; set; }
        public virtual Language? IdLanguageNavigation { get; set; }
        public virtual PublishingHouse? IdPublishingHouseNavigation { get; set; }
        public virtual Series? IdSeriesNavigation { get; set; }
        public virtual ICollection<ArtRead> ArtReads { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Possession> Possessions { get; set; }
    }
}
