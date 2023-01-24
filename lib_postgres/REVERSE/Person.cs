using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Person
    {
        public Person()
        {
            Locations = new HashSet<Location>();
            Possessions = new HashSet<Possession>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Possession> Possessions { get; set; }
    }
}
