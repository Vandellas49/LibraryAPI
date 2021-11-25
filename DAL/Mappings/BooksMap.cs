using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class BooksMap : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.CategoryId).IsRequired();
            builder.Property(a => a.PageCount).IsRequired();
            builder.Property(a => a.Shelf).IsRequired();
            builder.Property(a => a.Shelf).HasMaxLength(5).HasColumnType("NVARCHAR(5)");
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(350).HasColumnType("NVARCHAR(350)");
            builder.Property(a => a.Author).IsRequired();
            builder.Property(a => a.Author).HasMaxLength(150).HasColumnType("NVARCHAR(150)");
            builder.HasMany<BookRent>(a => a.BookRent).WithOne(c => c.Books).HasForeignKey(p => p.BookId);
            builder.HasMany<VisitorsBooks>(a => a.VisitorsBooks).WithOne(c => c.Books).HasForeignKey(p => p.VisitorId);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Books).HasForeignKey(p => p.CategoryId);
            builder.ToTable("Books");
        }
    }
}
