using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            builder.Property(a => a.UserName).IsRequired();
            builder.Property(a => a.UserName).HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(30).HasColumnType("varbinary(30)");
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            builder.HasMany<UserRole>(a => a.UserRole).WithOne(c => c.User).HasForeignKey(p => p.UserId);
            builder.ToTable("User");
            builder.HasData(
                new User
                {
                    Name = "Test",
                    Email = "test@gmail.com",
                    Password = System.Text.Encoding.ASCII.GetBytes("12345678"),
                    Surname = "Test",
                    UserName = "Test",
                    Id=1,
                }
                );
        }
    }
}
