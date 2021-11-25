using Enums;

namespace Entities.Dtos
{
    public class UserRoleAddDto
    {
        public int? UserId { get; set; }
        public Role? Role { get; set; }
        public static implicit operator UserRole(UserRoleAddDto model)
        {
            return new UserRole
            {
                Id = 0,
                Role = model.Role.Value,
                UserId = model.UserId.Value
            };
        }
    }
}
