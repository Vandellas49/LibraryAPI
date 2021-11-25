using Entities;

namespace BL.Specifications
{
    public class UserRoleWithFiltersForCountSpecification : BaseSpecifcation<UserRole>
    {
        public UserRoleWithFiltersForCountSpecification(UserRoleSearchParams userroleParams) : base(x =>
           (!userroleParams.UserId.HasValue || x.UserId == userroleParams.UserId) &&
           (!userroleParams.Role.HasValue || x.Role == userroleParams.Role)
         )
        {
        }
        public UserRoleWithFiltersForCountSpecification(int? Id) : base(x =>x.Id==Id)
        {
        }
    }
}
