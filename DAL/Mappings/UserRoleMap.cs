using Entities;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.Role).HasMaxLength(1).IsRequired().HasConversion<int>();
            builder.HasOne<User>(a => a.User).WithMany(c => c.UserRole).HasForeignKey(p => p.UserId);
            builder.ToTable("UserRole");
            builder.HasData(
                new UserRole
                {
                    UserId = 1,
                    Role = Role.Admin,
                    Id=1
                }
                );
        }
    }
}
