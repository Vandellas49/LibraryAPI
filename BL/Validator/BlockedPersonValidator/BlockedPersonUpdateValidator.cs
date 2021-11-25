using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator
{
    public class BlockedPersonUpdateValidator : AbstractValidator<BlockedPersonUpdateDto>
    {
        readonly IGenericRepository<BlockedPersons> repository;
        readonly IGenericRepository<Persons> personrepository;
        public BlockedPersonUpdateValidator(IGenericRepository<BlockedPersons> _repository, IGenericRepository<Persons> _personrepository)
        {
            repository = _repository;
            personrepository = _personrepository;
            RuleFor(x => x.Id).NotNull().WithMessage("Güncellenecek Ceza Id Boş Geçilmemelidir").
            Must(HasBlockedField).WithMessage("Ceza Bulunamadı");
            RuleFor(x => x.CreatedDate).
            NotNull().WithMessage("Ceza Başlangıç Tarihi Boş Geçilmemelidir");
            RuleFor(x => x.EndOfBlockedDate).
            NotNull().WithMessage("Ceza Bitiş Tarihi Boş Geçilmemelidir");
            RuleFor(x => x.Explanation).
            MaximumLength(300).WithMessage("Açıklama Kısmı 300 Geçmemelidir");
            RuleFor(x => x.PersonId).NotNull().WithMessage("PersonId alanı boş geçilmemelidir").
            Must(HasPersonField).WithMessage("Personel Bulunamadı");
        }

        private bool HasBlockedField(int? Id)
        {
            return !repository.Any(new BlockedPersonWithPersonSpecification(Id)).Result;
        }
        private bool HasPersonField(int? PersonelId)
        {
            return !personrepository.Any(new PersonSpecification(PersonelId)).Result;
        }
    }
}
