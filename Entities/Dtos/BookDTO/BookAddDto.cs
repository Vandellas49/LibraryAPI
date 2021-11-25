using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class BookAddDto
    {
        /// <summary>
        /// Kitap İsmi
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Kitap Yazarı
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Kitap Kategori Id si
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Kitap sayfa sayısı
        /// </summary>
        public int? PageCount { get; set; }
        /// <summary>
        /// Kitap raf alanı
        /// </summary>
        public string Shelf { get; set; }
        public static implicit operator Books(BookAddDto book)
        {
            return new Books
            {
                Name = book.Name,
                Id = 0,
                Author = book.Author,
                CategoryId = book.CategoryId.Value,
                PageCount = book.PageCount.Value,
                Shelf = book.Shelf,
            };
        }
    }
}
