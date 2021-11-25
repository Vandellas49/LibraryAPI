using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class BookDeleteValidator : AbstractValidator<BookDeleteDto>
    {
        readonly IGenericRepository<Books> repository;
        public BookDeleteValidator(IGenericRepository<Books> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek Kitap Id girinizi").
                Custom(HasBookField);
        }
        private void HasBookField(int? Id, ValidationContext<BookDeleteDto> context)
        {
            var exist = repository.GetByIdAsync(new BooksWithVisitorsBooksandBookRentByNameandIdAnySpecification(null, Id)).Result;
            if (exist == null)
                context.AddFailure("Kitap Bulunamadı");
            else if (exist.BookRent.Count > 0)
                context.AddFailure("Kitap Şu anda kütüphanede olmadığından silinemez");
            else if (exist.VisitorsBooks.Count > 0)
                context.AddFailure("Kitap Şu anda ziyaretçide olduğundan silinemez");
        }
    }
}
