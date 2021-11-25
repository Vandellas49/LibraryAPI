using Entities;

namespace BL.Specifications
{
    public class UsersWithFiltersForCountSpecification : BaseSpecifcation<User>
    {
        public UsersWithFiltersForCountSpecification(UserSearchParams userspecparams) : base(x =>
           (string.IsNullOrEmpty(userspecparams.Name) || x.Name.ToLower().Contains(userspecparams.Name)) &&
           (string.IsNullOrEmpty(userspecparams.SurName) || x.Surname.ToLower().Contains(userspecparams.SurName)) &&
           (string.IsNullOrEmpty(userspecparams.UserName) || x.UserName == userspecparams.UserName) &&
           (string.IsNullOrEmpty(userspecparams.Email) || x.Email.ToLower() == userspecparams.Email))
        {
            AddInclude(p => p.UserRole);
        }
        public UsersWithFiltersForCountSpecification(int? Id) : base(x =>x.Id==Id)
        {
            AddInclude(p => p.UserRole);
        }
    }
}
