using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}
