using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;
namespace BL.Validator
{
    public class PersonDeleteValidator : AbstractValidator<PersonDeleteDto>
    {
        readonly IGenericRepository<Persons> repository;
        public PersonDeleteValidator(IGenericRepository<Persons> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek Personel Id girinizi").
               Custom(HasPersonField);
        }
        private void HasPersonField(int? Id, ValidationContext<PersonDeleteDto> context)
        {
            var exist = repository.GetByIdAsync(new PersonWithBlockedPersonAndBookRentAndVisitorsSpecification(Id)).Result;
            if (exist == null)
                context.AddFailure("Kişi Bulunamadı");
            else if (exist.BlockedPersons.Count > 0)
                context.AddFailure("Silinmek istenilen kişi engelenilen listede olduğundan silinemez");
            else if (exist.BookRent.Count > 0)
                context.AddFailure("Silinmek istenilen kişin üzerinde kitap olduğundan silinemez");
            else if (exist.Visitors.Count > 0)
                context.AddFailure("Silinmek istenilen kişin ziyaretçi listesinde olduğundan silinemez");
        }
    }
}
