using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Mappings
{
    public class PersonsMap : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(30).HasColumnType("NVARCHAR(30)");   
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            builder.Property(a => a.PhoneNumber).IsRequired();
            builder.Property(a => a.PhoneNumber).HasMaxLength(12).HasColumnType("NVARCHAR(12)");
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            builder.Property(a => a.Address).IsRequired();
            builder.Property(a => a.Address).HasColumnType("NVARCHAR(MAX)");
            builder.HasMany<BlockedPersons>(a => a.BlockedPersons).WithOne(c => c.Persons).HasForeignKey(p => p.PersonId);
            builder.HasMany<BookRent>(a => a.BookRent).WithOne(c => c.Persons).HasForeignKey(p => p.PersonId);
            builder.HasMany<Visitors>(a => a.Visitors).WithOne(c => c.Persons).HasForeignKey(p => p.PersonId);
            builder.ToTable("Persons");


        }
    }
}
