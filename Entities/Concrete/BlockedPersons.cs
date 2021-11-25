using Enums;
using System;

namespace Entities
{
    public class BlockedPersons : BaseEntity
    {
        public int PersonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndOfBlockedDate { get; set; }
        public string Explanation { get; set; }
        public BlockedType Situation { get; set; }
        public virtual Persons Persons { get; set; }
    }
}
