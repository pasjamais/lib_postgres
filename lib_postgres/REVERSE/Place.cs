using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Place
    {
        public Place()
        {
            Actions = new HashSet<Action>();
            Locations = new HashSet<Location>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Comment { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
