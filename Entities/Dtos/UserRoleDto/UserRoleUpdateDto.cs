using Enums;

namespace Entities.Dtos
{
    public class UserRoleUpdateDto
    {
        public int? UserId { get; set; }
        public Role? Role { get; set; }
        public int? Id { get; set; }
        public static implicit operator UserRole(UserRoleUpdateDto model)
        {
            return new UserRole
            {
                Id = model.Id.Value,
                Role = model.Role.Value,
                UserId = model.UserId.Value
            };
        }
    }
}
