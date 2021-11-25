using Entities;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class BookRentMap : IEntityTypeConfiguration<BookRent>
    {
        public void Configure(EntityTypeBuilder<BookRent> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.PersonId).IsRequired(true);
            builder.Property(a => a.BookId).IsRequired(true);
            builder.Property(a => a.BroughtedfDate).IsRequired(false);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.EndOfRentDate).IsRequired();
            builder.Property(a => a.PersonId).HasMaxLength(50);
            builder.Property(a => a.Situation).HasMaxLength(1).IsRequired().HasConversion<int>();
            builder.HasOne<Persons>(a => a.Persons).WithMany(c => c.BookRent).HasForeignKey(p=>p.PersonId);
            builder.HasOne<Books>(a => a.Books).WithMany(c => c.BookRent).HasForeignKey(p=>p.BookId);
            builder.ToTable("BookRent");
        }
    }
}
