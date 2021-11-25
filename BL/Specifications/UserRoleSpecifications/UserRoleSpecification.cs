using Entities;
namespace BL.Specifications
{
    public class UserRoleSpecification : BaseSpecifcation<UserRole>
    {
        public UserRoleSpecification(UserRoleSearchPaginationParams userroleParams) : base(x =>
          (!userroleParams.UserId.HasValue || x.UserId==userroleParams.UserId)&& 
          (!userroleParams.Role.HasValue || x.Role == userroleParams.Role)
         )
        {
            ApplyPaging(userroleParams.PageSize * (userroleParams.PageIndex - 1), userroleParams.PageSize);
            //AddInclude(p => p.User);
            if (!string.IsNullOrEmpty(userroleParams.Sort))
            {
                switch (userroleParams.Sort)
                {
                    case "roleAsc":
                        AddOrderBy(p => p.Role);
                        break;
                    case "roleDesc":
                        AddOrderByDescending(p => p.Role);
                        break;
                    case "userIdAsc":
                        AddOrderBy(p => p.UserId);
                        break;
                    case "userIdDesc":
                        AddOrderByDescending(p => p.UserId);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }

        public UserRoleSpecification(int? id) : base(x => x.Id == id)
        {
            //AddInclude(p => p.User);
        }
    }
}
