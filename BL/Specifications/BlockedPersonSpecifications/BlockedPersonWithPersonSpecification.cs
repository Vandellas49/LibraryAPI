using Entities;

namespace BL.Specifications
{
    public class BlockedPersonWithPersonSpecification : BaseSpecifcation<BlockedPersons>
    {
        public BlockedPersonWithPersonSpecification(BlockedPersonsSearchPaginationParams personParams) : base(x =>
         (string.IsNullOrEmpty(personParams.Name) || x.Persons.Name.ToLower().Contains(personParams.Name)) &&
         (string.IsNullOrEmpty(personParams.SurName) || x.Persons.Surname.ToLower().Contains(personParams.SurName)) &&
         (string.IsNullOrEmpty(personParams.Email) || x.Persons.Email.ToLower().Contains(personParams.Email)) &&
         (string.IsNullOrEmpty(personParams.PhoneNumber) || x.Persons.PhoneNumber.ToLower().Contains(personParams.PhoneNumber)) &&
         (!personParams.CreatedDate.HasValue || x.CreatedDate.Date == personParams.CreatedDate.Value.Date)&&
         (!personParams.Situation.HasValue || x.Situation == personParams.Situation.Value)&&
         (!personParams.PersonId.HasValue || x.PersonId == personParams.PersonId.Value)&&
         (!personParams.EndOfBlockedDate.HasValue || x.EndOfBlockedDate.Date == personParams.EndOfBlockedDate.Value.Date))
        {
            AddInclude(x => x.Persons);
            ApplyPaging(personParams.PageSize * (personParams.PageIndex - 1), personParams.PageSize);
            if (!string.IsNullOrEmpty(personParams.Sort))
            {
                switch (personParams.Sort)
                {
                    case "createdDateAsc":
                        AddOrderBy(p => p.CreatedDate);
                        break;
                    case "createdDateDesc":
                        AddOrderByDescending(p => p.CreatedDate);
                        break;
                    case "endOfBlockedDateAsc":
                        AddOrderBy(p => p.EndOfBlockedDate);
                        break;
                    case "endOfBlockedDateDesc":
                        AddOrderByDescending(p => p.EndOfBlockedDate);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }

        public BlockedPersonWithPersonSpecification(int? id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Persons);
        }
    }
}
