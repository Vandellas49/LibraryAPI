using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Enums;
using FluentValidation;

namespace BL.Validator
{
    public class UserRoleAddValidator : AbstractValidator<UserRoleAddDto>
    {
        readonly IGenericRepository<UserRole> repository;
        readonly IGenericRepository<User> userrepository;
        public UserRoleAddValidator(IGenericRepository<UserRole> _repository, IGenericRepository<User> _userrepository)
        {
            repository = _repository;
            userrepository = _userrepository;
            RuleFor(x => x.UserId).
                NotNull().WithMessage("Kullanıcı Id Alanı Boş Olmamalıdır").
                Must(HasUserField).WithMessage("Kullanıcı Bulunamadı");

            RuleFor(x => x.Role).
                 NotNull().WithMessage("Role Alanı Boş Olmamalıdır").
                IsInEnum().WithMessage("Lütfen Role enum dışına çıkmayın").
            Must((x, role) => HasUserThisRole(role, x.UserId)).WithMessage("Kullanıcı Bu Role Sahip");
        }
        private bool HasUserField(int? UserId)
        {
            return userrepository.Any(new UserSpecification(UserId)).Result;
        }
        private bool HasUserThisRole(Role? role, int? UserId)
        {
            return !repository.Any(new UserRoleWithFiltersForCountSpecification(new UserRoleSearchParams { UserId = UserId, Role = role })).Result;
        }

    }
}
