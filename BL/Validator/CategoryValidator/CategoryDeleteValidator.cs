using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class CategoryDeleteValidator : AbstractValidator<CategoryDeleteDto>
    {
        readonly IGenericRepository<Category> repository;
        public CategoryDeleteValidator(IGenericRepository<Category> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek Kategori Id girinizi").
               Custom(HasCategoryField);
        }
        private void HasCategoryField(int? Id, ValidationContext<CategoryDeleteDto> context)
        {
            var exist = repository.GetByIdAsync(new CategoriesWithBooksSpecification(Id)).Result;
            if (exist == null)
                context.AddFailure("Kategori Bulunamadı");
            else if (exist.Books.Count > 0)
                context.AddFailure("Silinmek istenilen kategoride kitap bulunduğundan silinemez");
        }
    }
}
