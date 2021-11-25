using Enums;
using System;

namespace BL.Specifications
{
    public class BookRentSearchParams
    {
        public int? PersonId { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndOfRentDate { get; set; }
        public DateTime? BroughtedfDate { get; set; }
        public RentType? Situation { get; set; }
    }
}
