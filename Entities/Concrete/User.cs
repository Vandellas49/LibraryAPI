using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Password)]
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
