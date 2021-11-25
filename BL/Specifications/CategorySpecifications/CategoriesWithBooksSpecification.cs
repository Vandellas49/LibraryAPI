using Entities;
using System;
using System.Linq;

namespace BL.Specifications
{
    public class CategoriesWithBooksSpecification : BaseSpecifcation<Category>
    {
        public CategoriesWithBooksSpecification(CategorySearchParams categoryParams) : base(x =>
         (string.IsNullOrEmpty(categoryParams.Name) || x.Name.ToLower().Contains(categoryParams.Name)) &&
         (string.IsNullOrEmpty(categoryParams.Description) || x.Description.ToLower().Contains(categoryParams.Description)) &&
         (!categoryParams.BookId.HasValue || x.Books.Any(c => c.Id == categoryParams.BookId)))
        {
            AddInclude(x => x.Books);
            ApplyPaging(categoryParams.PageSize * (categoryParams.PageIndex - 1), categoryParams.PageSize);
            if (!string.IsNullOrEmpty(categoryParams.Sort))
            {
                switch (categoryParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "descriptionAsc":
                        AddOrderBy(p => p.Description);
                        break;
                    case "descriptionDesc":
                        AddOrderByDescending(p => p.Description);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }

        public CategoriesWithBooksSpecification(int? id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Books);
        }
    }
}
