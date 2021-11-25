using Entities;

namespace BL.Specifications
{
    public class PersonSpecification : BaseSpecifcation<Persons>
    {
        public PersonSpecification(PersonsSearchPaginationParams personParams) : base(x =>
         (string.IsNullOrEmpty(personParams.Name) || x.Name.ToLower().Contains(personParams.Name)) &&
         (string.IsNullOrEmpty(personParams.SurName) || x.Surname.ToLower().Contains(personParams.SurName) &&
         (string.IsNullOrEmpty(personParams.PhoneNumber) || x.PhoneNumber.ToLower().Contains(personParams.PhoneNumber) &&
         (string.IsNullOrEmpty(personParams.Email) || x.Email.ToLower().Contains(personParams.Email)))))
        {
            ApplyPaging(personParams.PageSize * (personParams.PageIndex - 1), personParams.PageSize);
            if (!string.IsNullOrEmpty(personParams.Sort))
            {
                switch (personParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "surnameAsc":
                        AddOrderBy(p => p.Surname);
                        break;
                    case "surnameDesc":
                        AddOrderByDescending(p => p.Surname);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }

        public PersonSpecification(int? id) : base(x => x.Id == id)
        {
        }
    }
}
