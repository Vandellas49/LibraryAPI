using Entities;
using System.Text;

namespace BL.Specifications
{
    public class UsersWithFiltersForAuthenticationSpecification : BaseSpecifcation<User>
    {
        public UsersWithFiltersForAuthenticationSpecification(UserSearchUserNamePasswordParams userspecparams) : base(x =>
           (string.IsNullOrEmpty(userspecparams.UserName) || x.UserName==userspecparams.UserName) &&
           (string.IsNullOrEmpty(userspecparams.Password) || x.Password==Encoding.ASCII.GetBytes(userspecparams.Password)))
        {
            AddInclude(p => p.UserRole);
        }
 
    }
}
