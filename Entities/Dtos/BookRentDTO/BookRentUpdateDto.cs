using Enums;
using System;

namespace Entities.Dtos
{
    public class BookRentUpdateDto
    {
        /// <summary>
        ///Güncellencek Kitabın Alınma Idsi
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        ///Kitap Id
        /// </summary>
        public int? BookId { get; set; }
        /// <summary>
        ///Kişi Id
        /// </summary>
        public int? PersonId { get; set; }
        /// <summary>
        ///Verilme Tarihi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///Alıncak Idsi
        /// </summary>
        public DateTime? EndOfRentDate { get; set; }
        /// <summary>
        ///Durum enum şeklinde
        /// </summary>
        /// <example>RentType.RentType=0,RentType.Delivered=1</example>
        public RentType? Situation { get; set; }
        public static implicit operator BookRent(BookRentUpdateDto br)
        {
            return new BookRent
            {
                BookId = br.BookId.Value,
                BroughtedfDate = null,
                CreatedDate = br.CreatedDate.Value,
                EndOfRentDate = br.EndOfRentDate.Value,
                PersonId = br.PersonId.Value,
                Situation = br.Situation.Value,
                Id = br.Id.Value
            };
        }
    }
}
