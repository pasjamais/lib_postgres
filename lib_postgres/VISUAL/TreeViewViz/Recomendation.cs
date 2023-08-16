using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.VISUAL.TreeViewViz
{
    public class Recomendation
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

        public string? Art_Source_Text;
        public string? Author_Source_Text;
        public string? SourceAnother_Text;
        public string? Art_ToRead_Text;
        public string? Author_ToRead_Text;
    }
}
