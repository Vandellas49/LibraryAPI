using Entities;

namespace BL.Specifications
{
    public class BooksByNameandIdAnySpecification : BaseSpecifcation<Books>
    {
        public BooksByNameandIdAnySpecification(string Name, int? Id) : base(x =>
      (string.IsNullOrEmpty(Name) || x.Name.ToLower().Contains(Name)) &&
      (!Id.HasValue || x.Id == Id))
        {

        }
    }
}
