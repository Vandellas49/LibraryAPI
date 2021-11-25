using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BL.Validator
{
    public class PersonAddValidator : AbstractValidator<PersonAddDto>
    {
        readonly IGenericRepository<Persons> repository;
        public PersonAddValidator(IGenericRepository<Persons> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Name).
                NotNull().WithMessage("İsim Alanı Boş Olmamalıdır").
            Length(3, 30).WithMessage("İsim uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır.");
            RuleFor(x => x.Surname).
                 NotNull().WithMessage("Soyisim Alanı Boş Olmamalıdır")
                .Length(3, 30).WithMessage("Soyisim uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Telefon Numarası Boş Geçilmemelidir").
                  Must(UniquePhoneField).WithMessage("Telefon Numarası zaten kayıtlı")
               .Must(IsPhoneNumber).WithMessage("Telefon numarası formatı yanlış girildi.")
                .Length(10).WithMessage("Telefon Numarası uzunluğu 10 karekterden oluşmalıdır");
            RuleFor(x => x.Email).
               NotNull().WithMessage("Email Alanı Boş Olmamalıdır").
                Must(UniqueEmailField).WithMessage("Email zaten kayıtlı").
               Length(8, 50).WithMessage("Email uzunluğu en az 8 en fazla 50 karekterden oluşmalıdır").
               EmailAddress().WithMessage("Email Giriniz");
            RuleFor(x => x.Address).
             NotNull().WithMessage("Adres Alanı Boş Olmamalıdır").
             MinimumLength(3).WithMessage("Adres uzunluğu en az 3 karekterden oluşmalıdır");
        }
        private bool UniquePhoneField(string phonenumber)
        {
            return !repository.Any(new PersonsWithFiltersForCountSpecification(new PersonsSearchParams { PhoneNumber = phonenumber })).Result;
        }
        private bool UniqueEmailField(string email)
        {
            return !repository.Any(new PersonsWithFiltersForCountSpecification(new PersonsSearchParams { Email = email })).Result;
        }
        private bool IsPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            return regex.IsMatch(arg);
        }

    }
}
