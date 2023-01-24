using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class Action
    {
        public Action()
        {
            Locations = new HashSet<Location>();
            Possessions = new HashSet<Possession>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public string? Comment { get; set; }
        public long? Place { get; set; }
        public long? ActionType { get; set; }

        public virtual ActionType? ActionTypeNavigation { get; set; }
        public virtual Place? PlaceNavigation { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Possession> Possessions { get; set; }
    }
}
