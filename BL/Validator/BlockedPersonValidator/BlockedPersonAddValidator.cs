using BL.InterFaces;
using BL.Specifications;
using Entities;
using Entities.Dtos;
using FluentValidation;
using System;

namespace BL.Validator
{
    public class BlockedPersonAddValidator : AbstractValidator<BlockedPersonAddDto>
    {
        readonly IGenericRepository<BlockedPersons> repository;
        readonly IGenericRepository<Persons> personrepository;
        public BlockedPersonAddValidator(IGenericRepository<BlockedPersons> _repository, IGenericRepository<Persons> _personrepository)
        {
            repository = _repository;
            personrepository = _personrepository;
            RuleFor(x => x.CreatedDate).
            NotNull().WithMessage("Ceza Başlangıç Tarihi Boş Geçilmemelidir");

            RuleFor(x => x.EndOfBlockedDate).
            NotNull().WithMessage("Ceza Bitiş Tarihi Boş Geçilmemelidir");

            RuleFor(x => x.Explanation).
            MaximumLength(300).WithMessage("Açıklama Kısmı 300 Geçmemelidir");

            RuleFor(x => x.PersonId).NotNull().WithMessage("PersonId alanı boş geçilmemelidir").
            Custom(HasPersonField);
        }

        private void HasPersonField(int? PersonelId, ValidationContext<BlockedPersonAddDto> context)
        {
            if (!personrepository.Any(new PersonSpecification(PersonelId)).Result)
                context.AddFailure("Kişi Bulunamadı");
            else if(repository.Any(new BlockedPersonWithPersonSpecification(new BlockedPersonsSearchPaginationParams {Situation=Enums.BlockedType.Blocked,PersonId=PersonelId })).Result)
                context.AddFailure("Kişide Ceza Bulunduğundan Eklenemez");
        }

    }
}
