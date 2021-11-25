using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Enums;
using FluentValidation;

namespace BL.Validator
{
    public class UserRoleUpdateValidator : AbstractValidator<UserRoleUpdateDto>
    {
        readonly IGenericRepository<UserRole> repository;
        readonly IGenericRepository<User> userrepository;
        UserRole ur = null;
        public UserRoleUpdateValidator(IGenericRepository<UserRole> _repository, IGenericRepository<User> _userrepository)
        {
            repository = _repository;
            userrepository = _userrepository;
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Güncellenecek UserRole Id giriniz").
             Must(HasUserRole).WithMessage("Bulunamadı");

            RuleFor(x => x.UserId).
                 NotNull().WithMessage("Kullanıcı Id Alanı Boş Olmamalıdır").
                 Must(HasUserField).WithMessage("Kullanıcı Bulunamadı");

            RuleFor(x => x.Role).
                 NotNull().WithMessage("Role Alanı Boş Olmamalıdır").
                 Must((x, role) => HasUserThisRole(role, x.UserId)).WithMessage("Kullanıcı Bu Role Sahip");
        }
        private bool HasUserRole(int? Id)
        {
            ur = repository.GetByIdAsync(new UserRoleWithFiltersForCountSpecification(Id)).Result;
            if (ur == null)
                return false;
            return true;
        }
        private bool HasUserField(int? UserId)
        {
            return userrepository.Any(new UserSpecification(UserId)).Result;
        }
        private bool HasUserThisRole(Role? role, int? UserId)
        {
            return !(ur != null && ur.Role != role && repository.Any(new UserRoleWithFiltersForCountSpecification(new UserRoleSearchParams { UserId = UserId, Role = role })).Result);
        }

    }
}
