using Entities;

namespace BL.Specifications
{
    public class PersonsWithFiltersForCountSpecification : BaseSpecifcation<Persons>
    {
        public PersonsWithFiltersForCountSpecification(PersonsSearchParams personspecparams) : base(x =>
           (string.IsNullOrEmpty(personspecparams.Name) || x.Name.ToLower().Contains(personspecparams.Name)) &&
           (string.IsNullOrEmpty(personspecparams.SurName) || x.Surname.ToLower().Contains(personspecparams.SurName)) &&
           (string.IsNullOrEmpty(personspecparams.PhoneNumber) || x.PhoneNumber == personspecparams.PhoneNumber) &&
           (string.IsNullOrEmpty(personspecparams.Email) || x.Email.ToLower() == personspecparams.Email))
        {
        }
        public PersonsWithFiltersForCountSpecification(int? Id) : base(x =>x.Id==Id)
        {
        }
    }
}
