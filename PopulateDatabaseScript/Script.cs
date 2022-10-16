using CsvHelper;
using CsvHelper.Configuration;
using MyDailyCoffee2.Model;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateDatabaseScript
{
    public static class Script
    {
        public static void Run()
        {
            EmptyDatabaseScript.Script.Run();
            DatabaseContext databaseContext = new DatabaseContext();
            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.HeaderValidated = null;
            csvConfiguration.MissingFieldFound = null;
            csvConfiguration.Delimiter = ";";
            StreamReader streamReader = new StreamReader("AzureUsers.csv");
            CsvReader csvReader = new CsvReader(streamReader, csvConfiguration);
            List<AzureUser> azureUsers = csvReader.GetRecords<AzureUser>().ToList();
            databaseContext.AddRange(azureUsers);
            databaseContext.SaveChanges();
            streamReader = new StreamReader("Customers.csv");
            csvReader = new CsvReader(streamReader, csvConfiguration);
            List<Customer> customers = csvReader.GetRecords<Customer>().ToList();
            azureUsers = databaseContext.AzureUsers.ToList();
            customers.ForEach(c => c.CreatedBy = c.UpdatedBy = azureUsers.First());
            databaseContext.AddRange(customers);
            streamReader = new StreamReader("MaterialBrands.csv");
            csvReader = new CsvReader(streamReader, csvConfiguration);
            List<MaterialBrand> materialBrands = csvReader.GetRecords<MaterialBrand>().ToList();
            databaseContext.MaterialBrands.AddRange(materialBrands);
            databaseContext.SaveChanges();
        }
    }
}
