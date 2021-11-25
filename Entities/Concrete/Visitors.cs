using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Visitors:BaseEntity
    {
        public int PersonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EndOfVisitDate { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual ICollection<VisitorsBooks> VisitorsBooks { get; set; }
    }
}
