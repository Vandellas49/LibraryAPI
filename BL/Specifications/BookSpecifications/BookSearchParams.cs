namespace BL.Specifications
{
    public class BookSearchParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? CategorId { get; set; }
        public string Sort { get; set; }
        private string _name;
        private string _shelf;
        public string Name
        {
            get => _name;
            set => _name = value.ToLower();
        }     
        public string Shelf
        {
            get => _shelf;
            set => _shelf = value.ToLower();
        }
        private string _author;
        public string Author
        {
            get => _author;
            set => _author = value.ToLower();
        }
    }
}
