using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class BookRentDeleteValidator : AbstractValidator<BookRentDeleteDto>
    {
        readonly IGenericRepository<BookRent> repository;
        public BookRentDeleteValidator(IGenericRepository<BookRent> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek Id giriniz").
            Must(HasBookRentField).WithMessage("Silinecek Data Bulunamadı");
        }
        private bool HasBookRentField(int? Id)
        {
            return !repository.Any(new BookRentAnySpecification(Id)).Result;
        }
    }
}
