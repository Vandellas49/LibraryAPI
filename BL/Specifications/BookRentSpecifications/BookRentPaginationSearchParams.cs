using Enums;
using System;

namespace BL.Specifications
{
    public class BookRentPaginationSearchParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string Sort { get; set; }
        public int? PersonId { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndOfRentDate { get; set; }
        public DateTime? BroughtedfDate { get; set; }
        public RentType? Situation { get; set; }
    }
}
