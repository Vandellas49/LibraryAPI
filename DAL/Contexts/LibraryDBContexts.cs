using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;

namespace DAL.Contexts
{
    public class LibraryDBContexts:DbContext
    {
        public DbSet<BlockedPersons> BlockedPersons { get; set; }
        public DbSet<BookRent> BookRent { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Visitors> Visitors { get; set; }
        public DbSet<VisitorsBooks> VisitorsBooks { get; set; }
        public LibraryDBContexts(DbContextOptions<LibraryDBContexts> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LibraryDB;Trusted_Connection=True;");

        }
    }
}
