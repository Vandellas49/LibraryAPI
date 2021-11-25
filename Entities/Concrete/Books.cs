using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Books:BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public int PageCount { get; set; }
        public string Shelf { get; set; }
        public virtual ICollection<BookRent> BookRent { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<VisitorsBooks> VisitorsBooks { get; set; }
    }
}
