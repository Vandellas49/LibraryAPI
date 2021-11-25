using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class VisitorsBooksMap : IEntityTypeConfiguration<VisitorsBooks>
    {
        public void Configure(EntityTypeBuilder<VisitorsBooks> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.VisitorId).IsRequired();
            builder.Property(a => a.BookId).IsRequired();
            builder.HasOne<Visitors>(a => a.Visitors).WithMany(c => c.VisitorsBooks).HasForeignKey(p => p.VisitorId);
            builder.HasOne<Books>(a => a.Books).WithMany(c => c.VisitorsBooks).HasForeignKey(p => p.BookId);
            builder.ToTable("VisitorsBooks");
        }
    }
}
