using LoadApi.Entities;
using LoanAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.DataAccess
#nullable disable
{
    public class LoanContext : DbContext

    {
        public LoanContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Address>()
                .Property(a => a.Street)
                .HasMaxLength(40);
            modelbuilder.Entity<Address>()
               .Property(a => a.City)
               .HasMaxLength(40);
            modelbuilder.Entity<Address>()
               .Property(a => a.Number)
               .HasMaxLength(20);

           /*modelbuilder.Entity<Loan>()
               .Property(l => l.CreateDate)
               .HasDefaultValue(DateTime.UtcNow);*/




        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<User> users { get; set; } 
    }
}
