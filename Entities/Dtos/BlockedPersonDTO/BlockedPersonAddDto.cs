using Enums;
using System;
namespace Entities.Dtos
{
    public class BlockedPersonAddDto
    {
        /// <summary>
        /// Ceza Başlangıç Tarihi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Ceza Bitiş Tarihi
        /// </summary>
        public DateTime? EndOfBlockedDate { get; set; }
        /// <summary>
        /// Ceza alma sebebi
        /// </summary>
        public string Explanation { get; set; }
        /// <summary>
        /// Ceza alan kişi
        /// </summary>
        public int? PersonId { get; set; }
        public static implicit operator BlockedPersons(BlockedPersonAddDto bp)
        {
            return new BlockedPersons
            {
                CreatedDate = bp.CreatedDate.Value,
                EndOfBlockedDate = bp.EndOfBlockedDate.Value,
                Explanation = bp.Explanation,
                PersonId = bp.PersonId.Value,
                Situation= BlockedType.Blocked,
                Id=0
            };
        }
    } 
}
