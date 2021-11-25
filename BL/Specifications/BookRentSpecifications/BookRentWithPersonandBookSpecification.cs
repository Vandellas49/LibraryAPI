using Entities;

namespace BL.Specifications
{
    public class BookRentWithPersonandBookSpecification : BaseSpecifcation<BookRent>
    {
        public BookRentWithPersonandBookSpecification(BookRentPaginationSearchParams rentbookParams) : base(x =>
          (!rentbookParams.PersonId.HasValue || x.PersonId == rentbookParams.PersonId) &&
          (!rentbookParams.BookId.HasValue || x.BookId == rentbookParams.BookId) &&
          (!rentbookParams.CreatedDate.HasValue || x.CreatedDate.Date == rentbookParams.CreatedDate.Value.Date) &&
          (!rentbookParams.EndOfRentDate.HasValue || x.EndOfRentDate.Date == rentbookParams.EndOfRentDate.Value.Date) &&
          (!rentbookParams.BroughtedfDate.HasValue || x.BroughtedfDate.Value.Date == rentbookParams.BroughtedfDate.Value.Date) &&
          (!rentbookParams.Situation.HasValue || x.Situation == rentbookParams.Situation.Value))
        {
            AddInclude(p => p.Books);
            AddInclude(p => p.Persons);
            ApplyPaging(rentbookParams.PageSize * (rentbookParams.PageIndex - 1), rentbookParams.PageSize);
            if (!string.IsNullOrEmpty(rentbookParams.Sort))
            {
                switch (rentbookParams.Sort)
                {
                    case "personAsc":
                        AddOrderBy(p => p.PersonId);
                        break;
                    case "personDesc":
                        AddOrderByDescending(p => p.PersonId);
                        break;
                    case "bookAsc":
                        AddOrderBy(p => p.BookId);
                        break;
                    case "bookDesc":
                        AddOrderByDescending(p => p.BookId);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }
        public BookRentWithPersonandBookSpecification(int? Id) : base(x => x.Id == Id)
        {
            AddInclude(p => p.Books);
            AddInclude(p => p.Persons);
        }
    }
}
