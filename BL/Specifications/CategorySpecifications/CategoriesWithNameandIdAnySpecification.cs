using Entities;

namespace BL.Specifications
{
    public class CategoriesWithNameandIdAnySpecification : BaseSpecifcation<Category>
    {
        public CategoriesWithNameandIdAnySpecification(string Name, int? Id) : base(x =>
            (string.IsNullOrEmpty(Name) || x.Name.ToLower().Contains(Name)) &&
          (!Id.HasValue || x.Id == Id))
        {

        }

    }
}
