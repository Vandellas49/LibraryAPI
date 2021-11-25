using Enums;

namespace Entities
{
    public class UserRole:BaseEntity
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
