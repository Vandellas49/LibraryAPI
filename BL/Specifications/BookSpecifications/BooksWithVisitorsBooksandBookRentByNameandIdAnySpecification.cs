using Entities;

namespace BL.Specifications
{
    public class BooksWithVisitorsBooksandBookRentByNameandIdAnySpecification : BaseSpecifcation<Books>
    {
        public BooksWithVisitorsBooksandBookRentByNameandIdAnySpecification(string Name, int? Id) : base(x =>
       (string.IsNullOrEmpty(Name) || x.Name.ToLower().Contains(Name)) &&
       (!Id.HasValue || x.Id == Id))
        {
            AddInclude(p => p.VisitorsBooks);
            AddInclude(p => p.BookRent);
        }
    }
}
