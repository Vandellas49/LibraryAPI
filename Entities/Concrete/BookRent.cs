using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BookRent : BaseEntity
    {
        public int BookId { get; set; }
        public int PersonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndOfRentDate { get; set; }
        public DateTime? BroughtedfDate { get; set; }
        public RentType Situation { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual Books Books { get; set; }
    }
}
