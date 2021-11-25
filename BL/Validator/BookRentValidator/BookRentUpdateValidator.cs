using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class BookRentUpdateValidator : AbstractValidator<BookRentUpdateDto>
    {
        readonly IGenericRepository<BookRent> repository;
        readonly IGenericRepository<Persons> personrepository;
        readonly IGenericRepository<Books> bookrepository;
        public BookRentUpdateValidator(IGenericRepository<BookRent> _repository, IGenericRepository<Persons> _personrepository, IGenericRepository<Books> _bookrepository)
        {
            repository = _repository;
            personrepository = _personrepository;
            bookrepository = _bookrepository;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Boş Geçilmemelidir");
            RuleFor(x => x.BookId).
            NotNull().WithMessage("Kitap Id Boş Geçilmemelidir").
            Must(HasBookField).WithMessage("Kitap Bulunamadı").
            Must(CanRentBookField).WithMessage("Kitap Başka bir kişide bulunduğundan verilemez");

            RuleFor(x => x.PersonId).
            NotNull().WithMessage("Kişi Id Boş Geçilmemelidir").
            Must(HasPersonField).WithMessage("Personel Bulunamadı");

            RuleFor(x => x.CreatedDate).
            NotNull().WithMessage("Kitap Alınma Tarihi Boş Geçilemez");

            RuleFor(x => x.EndOfRentDate).
            NotNull().WithMessage("Kitap Son Verilmez Tarihi Boş Geçilemez");

            RuleFor(x => x.Situation).NotNull().WithMessage("Alan Boş Geçilemez").
                IsInEnum().WithMessage("Lütfen RentType enum dışına çıkmayın");

        }
        private bool HasBookField(int? Id)
        {
            return !bookrepository.Any(new BooksByNameandIdAnySpecification(null, Id)).Result;
        }
        private bool CanRentBookField(int? Id)
        {
            return repository.Any(new BookRentAnySpecification(new BookRentSearchParams { BookId = Id, Situation = Enums.RentType.Delivered })).Result;
        }
        private bool HasPersonField(int? Id)
        {
            return !personrepository.Any(new PersonsWithFiltersForCountSpecification(Id)).Result;
        }
    }
}
