namespace Entities.Dtos
{
    public class BookUpdateDto
    {
        public int? Id { get; set; }
        /// <summary>
        /// Güncellenecek Kitap ismi
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Güncellenecek Kitap Yazarı
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Güncellenecek Kitap Kategori Idsi
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Güncellenecek Kitap Sayfası
        /// </summary>
        public int? PageCount { get; set; }
        /// <summary>
        /// Güncellenecek Kitap Rafı
        /// </summary>
        public string Shelf { get; set; }
        public static implicit operator Books(BookUpdateDto book)
        {
            return new Books
            {
                Name = book.Name,
                Id = book.Id.Value,
                Author = book.Author,
                CategoryId = book.CategoryId.Value,
                PageCount = book.PageCount.Value,
                Shelf = book.Shelf,
            };
        }
    }

}
