using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        readonly IGenericRepository<Category> repository;
        public CategoryAddValidator(IGenericRepository<Category> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Name).Length(3, 30).WithMessage("Kategori ismi uzunluğu en az 3 en fazla 30 karekterden oluşmalıdır.").
            Must(UniqueNameField).WithMessage("Kategori Zaten Kayıtlı");
            RuleFor(x => x.Description).Length(3, 500).WithMessage("Tanımlama uzunluğu en az 3 en fazla 500 karekterden oluşmalıdır");
        }
        private bool UniqueNameField(string name)
        {
            return !repository.Any(new CategoriesWithNameandIdAnySpecification(name, null)).Result;
        }
    }
}
