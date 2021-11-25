using Entities;
using System;
using System.Linq;

namespace BL.Specifications
{
    public class CategoriesWithFiltersForCountSpecification : BaseSpecifcation<Category>
    {
        public CategoriesWithFiltersForCountSpecification(CategorySearchParams categoryspecparams) : base(x =>
           (string.IsNullOrEmpty(categoryspecparams.Name) || x.Name.ToLower().Contains(categoryspecparams.Name)) &&
           (string.IsNullOrEmpty(categoryspecparams.Description) || x.Description.ToLower().Contains(categoryspecparams.Description)) &&
           (!categoryspecparams.BookId.HasValue || x.Books.Any(t => t.Id == categoryspecparams.BookId)))
        {
            AddInclude(c => c.Books);
        }

    }
}
