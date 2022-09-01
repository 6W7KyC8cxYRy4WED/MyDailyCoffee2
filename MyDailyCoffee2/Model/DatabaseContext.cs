using Microsoft.EntityFrameworkCore;

namespace MyDailyCoffee2.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPhoneNumber>().HasKey(cpn => new { cpn.CustomerId, cpn.PhoneNumber });
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers => Set<CustomerPhoneNumber>();
    }
}
