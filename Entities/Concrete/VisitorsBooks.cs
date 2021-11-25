namespace Entities
{
    public class VisitorsBooks:BaseEntity
    {
        public int VisitorId { get; set; }
        public int BookId { get; set; }
        public virtual Visitors Visitors { get; set; }
        public virtual Books Books { get; set; }
    }
}
