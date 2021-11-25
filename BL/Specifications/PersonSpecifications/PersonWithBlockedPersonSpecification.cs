using Entities;

namespace BL.Specifications
{
    public class PersonWithBlockedPersonSpecification : BaseSpecifcation<Persons>
    {
        public PersonWithBlockedPersonSpecification(int? id) : base(x => x.Id == id)
        {
            AddInclude(p => p.BlockedPersons);
        }
    }
}
