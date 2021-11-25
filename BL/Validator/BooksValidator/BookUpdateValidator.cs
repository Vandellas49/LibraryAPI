using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class BookUpdateValidator : AbstractValidator<BookUpdateDto>
    {
        readonly IGenericRepository<Books> repository;
        readonly IGenericRepository<Category> categoryrepository;
        public BookUpdateValidator(IGenericRepository<Books> _repository, IGenericRepository<Category> _categoryrepository)
        {
            categoryrepository = _categoryrepository;
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Güncellenecek Kitap Id girinizi").
           Must(HasBookField).WithMessage("Kitap Bulunamadı");
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
        private bool HasBookField(int? Id)
        {
            return !repository.Any(new BooksByNameandIdAnySpecification(null, Id)).Result;
        }
        private bool HasCategoryField(int? Id)
        {
            return categoryrepository.Any(new CategoriesWithNameandIdAnySpecification(null, Id)).Result;
        }
    }
}
