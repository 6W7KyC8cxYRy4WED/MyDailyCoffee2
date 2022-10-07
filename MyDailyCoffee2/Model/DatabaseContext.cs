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
            modelBuilder.Entity<Customer>().HasOne(c => c.CreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne(c => c.UpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers => Set<CustomerPhoneNumber>();

        public DbSet<AzureUser> AzureUsers => Set<AzureUser>();
    }
}
