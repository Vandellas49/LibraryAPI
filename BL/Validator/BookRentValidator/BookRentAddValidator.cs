using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using Enums;
using FluentValidation;
using System;
using System.Linq;

namespace BL.Validator
{
    public class BookRentAddValidator : AbstractValidator<BookRentAddDto>
    {
        readonly IGenericRepository<BookRent> repository;
        readonly IGenericRepository<Persons> personrepository;
        readonly IGenericRepository<Books> bookrepository;
        public BookRentAddValidator(IGenericRepository<BookRent> _repository, IGenericRepository<Persons> _personrepository, IGenericRepository<Books> _bookrepository)
        {
            repository = _repository;
            personrepository = _personrepository;
            bookrepository = _bookrepository;
            RuleFor(x => x.BookId).
            NotNull().WithMessage("Kitap Id Boş Geçilmemelidir").
            Must(HasBookField).WithMessage("Kitap Bulunamadı").
            Must(CanRentBookField).WithMessage("Kitap Başka bir kişide bulunduğundan verilemez");

            RuleFor(x => x.PersonId).
            NotNull().WithMessage("Kitap Id Boş Geçilmemelidir").
            Custom(HasPersonField);

            RuleFor(x => x.CreatedDate).
            NotNull().WithMessage("Kitap Alınma Tarihi Boş Geçilemez");

            RuleFor(x => x.EndOfRentDate).
            NotNull().WithMessage("Kitap Son Verilmez Tarihi Boş Geçilemez");

        }

        private void HasPersonField(int? Id, ValidationContext<BookRentAddDto> context)
        {
            var r = personrepository.GetByIdAsync(new PersonWithBlockedPersonSpecification(Id)).Result;
            if (r == null)
                context.AddFailure("Kişi Bulunamadı");
            if(r.BlockedPersons.Any(p=>p.Situation== BlockedType.Blocked))
                context.AddFailure("Kişi Kitap Alamaz");
        }
        private bool HasBookField(int? Id)
        {
            return !bookrepository.Any(new BooksByNameandIdAnySpecification(null, Id)).Result;
        }
        private bool CanRentBookField(int? Id)
        {
            return repository.Any(new BookRentAnySpecification(new BookRentSearchParams { BookId = Id, Situation = Enums.RentType.Delivered })).Result;
        }
    }
}
