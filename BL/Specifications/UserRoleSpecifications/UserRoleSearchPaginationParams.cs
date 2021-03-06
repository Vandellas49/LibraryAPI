using Enums;

namespace BL.Specifications
{
    public class UserRoleSearchPaginationParams
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
        public int? UserId { get; set; }
        public Role? Role { get; set; }
    }
}
