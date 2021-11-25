using Entities;

namespace BL.Specifications
{
    public class PersonWithBlockedPersonAndBookRentAndVisitorsSpecification: BaseSpecifcation<Persons>
    {
        public PersonWithBlockedPersonAndBookRentAndVisitorsSpecification(int? id) : base(x => x.Id == id)
        {
            AddInclude(p => p.BookRent);
            AddInclude(p => p.Visitors);
            AddInclude(p => p.BlockedPersons);
        }
    }
}
