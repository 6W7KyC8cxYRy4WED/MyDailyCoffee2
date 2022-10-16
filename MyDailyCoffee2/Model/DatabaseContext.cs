using Microsoft.EntityFrameworkCore;

namespace MyDailyCoffee2.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public void Configure()
        {
            if (MaterialMeasurementTypes.Count() == 0)
            {
                MaterialMeasurementTypes.AddRange(MaterialMeasurementType.GetMaterialMeasurementTypes());
            }

            if (MaterialMeasurements.Count() == 0)
            {
                MaterialMeasurements.AddRange(MaterialMeasurement.GetMaterialMeasurements());
            }

            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<Program>(true).Build();
                string connectionString = configuration.GetConnectionString("DevelopDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasOne(c => c.CreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne(c => c.UpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers => Set<CustomerPhoneNumber>();

        public DbSet<AzureUser> AzureUsers => Set<AzureUser>();

        public DbSet<Material> Materials => Set<Material>();

        public DbSet<MaterialMeasurementType> MaterialMeasurementTypes => Set<MaterialMeasurementType>();

        public DbSet<MaterialMeasurement> MaterialMeasurements => Set<MaterialMeasurement>();

        public DbSet<MaterialLine> MaterialLines => Set<MaterialLine>();

        public DbSet<MaterialBrand> MaterialBrands => Set<MaterialBrand>();

        public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();

        public DbSet<Provider> Providers => Set<Provider>();
    }
}
