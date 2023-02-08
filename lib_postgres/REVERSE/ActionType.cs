using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class ActionType
    {
        public ActionType()
        {
            Actions = new HashSet<Action>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public bool? Operation { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}

