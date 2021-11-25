using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        readonly IGenericRepository<User> repository;
        User u = null;
        public UserUpdateValidator(IGenericRepository<User> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Güncellenecek Kişi Id giriniz").
            Custom(HasUser);
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen isim alanını boş geçmeyiniz")
            .Length(3, 30).WithMessage("User ismi uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır.");
            RuleFor(x => x.UserName).NotNull().WithMessage("Lütfen username alanını boş geçmeyiniz")
           .Length(3, 30).WithMessage("Username uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır");
            RuleFor(x => x.Surname).NotNull().WithMessage("Lütfen soyadı alanını boş geçmeyiniz")
           .Length(3, 30).WithMessage("Soyadı uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır");
            RuleFor(x => x.Password).NotNull().WithMessage("Lütfen şifre alanını boş geçmeyiniz")
           .Length(3, 10).WithMessage("Şifre en az 3 en fazla 10 karekterden oluşmalıdır.");
            RuleFor(x => x.Email).
               NotNull().WithMessage("Email Alanı Boş Olmamalıdır").
                Must(UniqueEmailField).WithMessage("Email zaten kayıtlı").
               Length(8, 50).WithMessage("Email uzunluğu en az 8 en fazla 50 karekterden oluşmalıdır").
               EmailAddress().WithMessage("Email Giriniz");

        }
        private void HasUser(int? Id, ValidationContext<UserUpdateDto> context)
        {
            u = repository.GetByIdAsync(new UserSpecification(Id)).Result;
            if (u == null)
                context.AddFailure("Kişi Bulunamadı");
        }
        private bool UniqueEmailField(string email)
        {
            return !(u != null && u.Email != email && repository.Any(new UsersWithFiltersForCountSpecification(new UserSearchParams { Email = email })).Result);
        }
    }
}
