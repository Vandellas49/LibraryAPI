using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class VisitorsMap : IEntityTypeConfiguration<Visitors>
    {
        public void Configure(EntityTypeBuilder<Visitors> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.PersonId).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.EndOfVisitDate).IsRequired(false);
            builder.HasMany<VisitorsBooks>(a => a.VisitorsBooks).WithOne(c => c.Visitors).HasForeignKey(p => p.VisitorId);
            builder.HasOne<Persons>(a => a.Persons).WithMany(c => c.Visitors).HasForeignKey(p => p.PersonId);
            builder.ToTable("Visitors");
        }
    }
}
