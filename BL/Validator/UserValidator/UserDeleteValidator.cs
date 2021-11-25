using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class UserDeleteValidator : AbstractValidator<UserDeleteDto>
    {
        readonly IGenericRepository<User> repository;
        public UserDeleteValidator(IGenericRepository<User> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek User Id girinizi").
               Custom(HasUserField);
        }
        private void HasUserField(int? Id, ValidationContext<UserDeleteDto> context)
        {
            var exist = repository.GetByIdAsync(new UsersWithFiltersForCountSpecification(Id)).Result;
            if (exist == null)
                context.AddFailure("Kullanıcı Bulunamadı");
            else if (exist.UserRole.Count > 0)
                context.AddFailure("Silinmek istenilen Userın rolü bulunduğundan silinemez");
        }
    }
}
