using Entities;

namespace BL.Specifications
{
    public class BooksWithCategorySpecification : BaseSpecifcation<Books>
    {
        public BooksWithCategorySpecification(BookSearchParams bookParams) : base(x =>
         (string.IsNullOrEmpty(bookParams.Name) || x.Name.ToLower().Contains(bookParams.Name)) &&
         (string.IsNullOrEmpty(bookParams.Author) || x.Author.ToLower().Contains(bookParams.Author)) &&
         (!bookParams.CategorId.HasValue || x.CategoryId==bookParams.CategorId))
        {
            AddInclude(x => x.Category);
            ApplyPaging(bookParams.PageSize * (bookParams.PageIndex - 1), bookParams.PageSize);
            if (!string.IsNullOrEmpty(bookParams.Sort))
            {
                switch (bookParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "authorAsc":
                        AddOrderBy(p => p.Author);
                        break;
                    case "authorDesc":
                        AddOrderByDescending(p => p.Author);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }

        public BooksWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}
