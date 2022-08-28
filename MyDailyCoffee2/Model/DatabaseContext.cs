using Microsoft.EntityFrameworkCore;

namespace MyDailyCoffee2.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
