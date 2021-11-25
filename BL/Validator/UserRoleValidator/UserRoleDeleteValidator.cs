using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;
namespace BL.Validator
{
    public class UserRoleDeleteValidator : AbstractValidator<UserRoleDeleteDto>
    {
        readonly IGenericRepository<UserRole> repository;
        public UserRoleDeleteValidator(IGenericRepository<UserRole> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek UserRole Id girinizi").
               Must(HasUserRole).WithMessage("Bulunamadı");
        }
        private bool HasUserRole(int? Id)
        {
            return repository.Any(new UserRoleWithFiltersForCountSpecification(Id)).Result;

        }
    }
}
