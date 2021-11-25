using Enums;
using System;

namespace Entities.Dtos
{
    public class BlockedPersonUpdateDto
    {
        /// <summary>
        /// Cezası güncellenecek ceza Id
        /// </summary>
        public int? Id { get; set; }
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
        /// <summary>
        /// Ceza alma durumu enum şeklindedir 
        /// </summary>
        /// <example>BlockedType.Blocked yada BlockedType.UnBlocked</example>
        public BlockedType? Situation { get; set; }
        public static implicit operator BlockedPersons(BlockedPersonUpdateDto bp)
        {
            return new BlockedPersons
            {
                CreatedDate = bp.CreatedDate.Value,
                EndOfBlockedDate = bp.EndOfBlockedDate.Value,
                Explanation = bp.Explanation,
                PersonId = bp.PersonId.Value,
                Situation = bp.Situation.Value,
                Id = bp.Id.Value
            };
        }
    }
}
