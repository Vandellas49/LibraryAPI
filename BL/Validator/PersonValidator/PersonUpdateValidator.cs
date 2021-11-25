using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BL.Validator
{
    public class PersonUpdateValidator : AbstractValidator<PersonUpdateDto>
    {
        readonly IGenericRepository<Persons> repository;
        Persons p = null;
        public PersonUpdateValidator(IGenericRepository<Persons> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Güncellenecek Kişi Id giriniz").
            Custom(HasPerson);

            RuleFor(x => x.Name).
            NotNull().WithMessage("İsim Alanı Boş Olmamalıdır").
            Length(3, 30).WithMessage("İsim uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır.");

            RuleFor(x => x.Surname).
            NotNull().WithMessage("Soyisim Alanı Boş Olmamalıdır").
            Length(3, 30).WithMessage("Soyisim uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır");

            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Telefon Numarası Boş Geçilmemelidir").
            Must(UniquePhoneField).WithMessage("Kategori Zaten Kayıtlı").
            Must(IsPhoneNumber).WithMessage("Telefon numarası formatı yanlış girildi.").
            Length(10).WithMessage("Telefon Numarası uzunluğu 10 karekterden oluşmalıdır");

            RuleFor(x => x.Email).
            NotNull().WithMessage("Email Alanı Boş Olmamalıdır").
            Must(UniqueEmailField).WithMessage("Email Zaten Kayıtlı").
            Length(8, 50).WithMessage("Email uzunluğu en az 8 en fazla 50 karekterden oluşmalıdır").
            EmailAddress().WithMessage("Geçersiz Eposta adresi Girdiniz");

            RuleFor(x => x.Address).
            NotNull().WithMessage("Adres Alanı Boş Olmamalıdır").
            MinimumLength(3).WithMessage("Adres uzunluğu en az 3 karekterden oluşmalıdır");
        }
        private void HasPerson(int? Id, ValidationContext<PersonUpdateDto> context)
        {
           p= repository.GetByIdAsync(new PersonSpecification(Id)).Result;
            if (p == null)
                context.AddFailure("Kişi Bulunamadı");
        }
        private bool UniquePhoneField(string phonenumber)
        {
            return !(p!=null&&p.PhoneNumber != phonenumber && repository.Any(new PersonsWithFiltersForCountSpecification(new PersonsSearchParams { PhoneNumber = phonenumber })).Result);
        }
        private bool UniqueEmailField(string email)
        {
            return !(p != null&&p.Email != email && repository.Any(new PersonsWithFiltersForCountSpecification(new PersonsSearchParams { Email = email })).Result);
        }
        private bool IsPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            return regex.IsMatch(arg);
        }

    }
}
