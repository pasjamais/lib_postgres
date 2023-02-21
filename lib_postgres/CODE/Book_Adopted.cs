using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.CODE
{
    public class Book_Adopted
    {
        public long Id { get; set; }
        public string? PublicationYear { get; set; }
        public string? PublishingHouse { get; set; }
        public string? PublishingLanguage { get; set; }
        public string? City { get; set; }
        public int? Pages { get; set; }
        public string? IdSeries { get; set; }
        public string? Code { get; set; }
        public bool? HasJacket { get; set; }
        public string? Comment { get; set; }
        public string? Notes { get; set; }
        public int? State { get; set; }
        public string? FamilyNotes { get; set; }
        public bool? IsArtBook { get; set; }

        public string Name { get; set; } = null!;
        public string? Genre { get; set; }
        public string? WritingYear { get; set; }
        public string? OrigLanguage { get; set; }
        public string? Authors { get; set; }
    }
}
