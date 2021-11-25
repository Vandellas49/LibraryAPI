using System;

namespace Entities.Dtos
{
    public class BookRentAddDto
    {
        /// <summary>
        /// Verilecek Kitap Id
        /// </summary>
        public int? BookId { get; set; }
        /// <summary>
        /// Verilecek Kişi Id
        /// </summary>
        public int? PersonId { get; set; }
        /// <summary>
        /// Verilme Tarihi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///Kitabın Alınacağı sın Tarih
        /// </summary>
        public DateTime? EndOfRentDate { get; set; }
        public static implicit operator BookRent(BookRentAddDto br)
        {
            return new BookRent
            {
                BookId = br.BookId.Value,
                BroughtedfDate = null,
                CreatedDate = br.CreatedDate.Value,
                EndOfRentDate = br.EndOfRentDate.Value,
                PersonId = br.PersonId.Value,
                Situation = Enums.RentType.Receipt
            };
        }
    }
}
