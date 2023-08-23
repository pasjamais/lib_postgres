using lib_postgres.CODE.CRUD;
using System;
using System.Collections.Generic;

namespace lib_postgres
{
    public partial class City : CODE.CRUD.IHas_field_IsDeleted, CODE.CRUD.IHas_field_ID, IHas_field_Name
    {
        public City()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
