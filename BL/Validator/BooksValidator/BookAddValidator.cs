using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class BookAddValidator : AbstractValidator<BookAddDto>
    {
        readonly IGenericRepository<Category> repository;
        public BookAddValidator(IGenericRepository<Category> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Name).
            NotNull().WithMessage("Kitap İsmi Boş Geçilmemelidir").
            Length(3, 350).WithMessage("Kitap ismi uzunluğu en az 3 en fazla 350 karekterden oluşmalıdır.");

            RuleFor(x => x.Author).
            NotNull().WithMessage("Yazar Boş Geçilmemelidir").
            Length(3, 150).WithMessage("Yazar uzunluğu en az 3 en fazla 150 karekterden oluşmalıdır.");

            RuleFor(x => x.Shelf).
            NotNull().WithMessage("Raf Alanı Boş Geçilmemelidir").
            Length(1, 5).WithMessage("Raf uzunluğu en az 1 en fazla 5 karekterden oluşmalıdır.");

            RuleFor(x => x.CategoryId).NotNull().WithMessage("CategoryId alanı boş geçilmemelidir").
            Must(HasCategoryField).WithMessage("Kategori Bulunamadı");
            RuleFor(x => x.PageCount).NotNull().WithMessage("Sayfa sayısı boş geçilmemelidir");
        }
        private bool HasCategoryField(int? Id)
        {
            return repository.Any(new CategoriesWithNameandIdAnySpecification(null,Id)).Result;
        }
    }
}
