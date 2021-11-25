using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;

namespace BL.Validator.BlockedPersonValidator
{
    public class BlockedPersonDeleteValidator : AbstractValidator<BlockedPersonDeleteDto>
    {
        readonly IGenericRepository<BlockedPersons> repository;
        public BlockedPersonDeleteValidator(IGenericRepository<BlockedPersons> _repository)
        {
            repository = _repository;
            RuleFor(x => x.Id).NotNull().WithMessage("Silinecek Ceza Id girinizi").
                Must(HasBlockedField);
        }
        private bool HasBlockedField(int? Id)
        {
            return repository.Any(new BlockedPersonWithPersonSpecification(Id)).Result;
        }
    }
}
