using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            builder.Property(a => a.Description).IsRequired(false);
            builder.Property(a => a.Description).HasMaxLength(500).HasColumnType("NVARCHAR(500)");
            builder.HasMany<Books>(a => a.Books).WithOne(c => c.Category).HasForeignKey(p=>p.CategoryId);
            builder.ToTable("Category");
        }
    }
}
