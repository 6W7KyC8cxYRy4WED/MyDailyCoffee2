using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using MyDailyCoffee2.Model;
using System.Globalization;

namespace MyDailyCoffee2.TestData
{
    public static class DatabasePopulator
    {
        public static void Populate()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.RemoveRange(databaseContext.CustomerPhoneNumbers);
            databaseContext.RemoveRange(databaseContext.Customers);
            databaseContext.RemoveRange(databaseContext.AzureUsers);
            databaseContext.SaveChanges();
            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.HeaderValidated = null;
            csvConfiguration.MissingFieldFound = null;
            csvConfiguration.Delimiter = ";";
            StreamReader streamReader = new StreamReader(@"TestData\AzureUsers.csv");
            CsvReader csvReader = new CsvReader(streamReader, csvConfiguration);
            List<AzureUser> azureUsers = csvReader.GetRecords<AzureUser>().ToList();
            databaseContext.AddRange(azureUsers);
            databaseContext.SaveChanges();
            streamReader = new StreamReader(@"TestData\Customers.csv");
            csvReader = new CsvReader(streamReader, csvConfiguration);
            List<Customer> customers = csvReader.GetRecords<Customer>().ToList();
            azureUsers = databaseContext.AzureUsers.ToList();
            customers.ForEach(c => c.CreatedBy = c.UpdatedBy = azureUsers.First());

            foreach (Customer customer in customers)
            {
                databaseContext.Add(customer);
            }

            databaseContext.SaveChanges();
        }
    }
}
