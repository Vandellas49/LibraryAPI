﻿using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Persons:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public virtual ICollection<BlockedPersons> BlockedPersons { get; set; }
        public virtual ICollection<BookRent> BookRent { get; set; }
        public virtual ICollection<Visitors> Visitors { get; set; }
    }
}
