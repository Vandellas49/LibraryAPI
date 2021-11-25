using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        readonly IGenericRepository<Category> repository;
        public CategoryUpdateValidator(IGenericRepository<Category> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Güncellenecek Kategori Id girinizi").
            Must(HasCategoryField).WithMessage("Kategori Bulunamadı");
            RuleFor(x => x.Name).Length(3, 30).WithMessage("Kategori ismi uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır.").
            Must((x, Name) => UniqueNameField(Name, x.Id)).WithMessage("Kategori Zaten Kayıtlı");
            RuleFor(x => x.Description).Length(3, 500).WithMessage("Tanımlama uzunluğu en az 3 en fazla 500 karekterden oluşmalıdır");
        }
        private bool HasCategoryField(int? Id)
        {
            return repository.Any(new CategoriesWithNameandIdAnySpecification(null, Id)).Result;
        }
        private bool UniqueNameField(string name, int? Id)
        {
            var entity = repository.GetByIdAsync(new CategoriesWithBooksSpecification(Id)).Result;
            if (entity == null)
                return false;
            if (entity.Name != name && repository.Any(new CategoriesWithNameandIdAnySpecification(name, null)).Result)
                return false;
            return true;
        }
    }
}
