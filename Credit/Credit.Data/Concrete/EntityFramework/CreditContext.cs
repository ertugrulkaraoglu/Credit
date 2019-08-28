using Credit.Entities;
using Microsoft.EntityFrameworkCore;

namespace Credit.Data.Concrete.EntityFramework
{
    public class CreditContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Credit;Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerScore> CustomerScores { get; set; }
        public DbSet<CustomerHistory> CustomerHistories { get; set; }
    }
}