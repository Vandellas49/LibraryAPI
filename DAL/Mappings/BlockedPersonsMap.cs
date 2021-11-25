using Entities;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class BlockedPersonsMap : IEntityTypeConfiguration<BlockedPersons>
    {
        public void Configure(EntityTypeBuilder<BlockedPersons> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.EndOfBlockedDate).IsRequired();
            builder.Property(a => a.Explanation).HasMaxLength(300).HasColumnType("NVARCHAR(300)");
            builder.Property(a => a.PersonId).IsRequired();
            builder.Property(a => a.Situation).HasMaxLength(1).IsRequired().HasConversion<int>(); 
            builder.HasOne<Persons>(a => a.Persons).WithMany(c => c.BlockedPersons).HasForeignKey(p=>p.PersonId);
            builder.ToTable("BlockedPersons");
        }
    }
}
