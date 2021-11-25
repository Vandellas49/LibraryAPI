
using Entities;

namespace BL.Specifications
{
    public class BookRentAnySpecification : BaseSpecifcation<BookRent>
    {
        public BookRentAnySpecification(BookRentSearchParams rentbookParams) : base(x =>
           (!rentbookParams.PersonId.HasValue || x.PersonId == rentbookParams.PersonId) &&
           (!rentbookParams.BookId.HasValue || x.BookId == rentbookParams.BookId) &&
           (!rentbookParams.CreatedDate.HasValue || x.CreatedDate.Date == rentbookParams.CreatedDate.Value.Date) &&
           (!rentbookParams.EndOfRentDate.HasValue || x.EndOfRentDate.Date == rentbookParams.EndOfRentDate.Value.Date) &&
           (!rentbookParams.BroughtedfDate.HasValue || x.BroughtedfDate.Value.Date == rentbookParams.BroughtedfDate.Value.Date) &&
           (!rentbookParams.Situation.HasValue || x.Situation == rentbookParams.Situation.Value))
        {
            
        }
        public BookRentAnySpecification(int? Id) : base(x =>x.Id==Id)
        {

        }
    }
}
