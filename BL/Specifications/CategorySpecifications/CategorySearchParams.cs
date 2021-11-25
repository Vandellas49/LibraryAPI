namespace BL.Specifications
{
    public class CategorySearchParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BookId { get; set; }
        public string Sort { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set => _name=value.ToLower();
        }
        private string _description;
        public string Description
        {
            get => _description;
            set => _description = value.ToLower();
        }
    }
}
