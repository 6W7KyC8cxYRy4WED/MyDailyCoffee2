using MyDailyCoffee2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyDatabaseScript
{
    public static class Script
    {
        public static void Run()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.RemoveRange(databaseContext.CustomerPhoneNumbers);
            databaseContext.SaveChanges();
            databaseContext.RemoveRange(databaseContext.Customers);
            databaseContext.SaveChanges();
            databaseContext.RemoveRange(databaseContext.AzureUsers);
            databaseContext.SaveChanges();
            databaseContext.RemoveRange(databaseContext.MaterialBrands);
            databaseContext.SaveChanges();
        }
    }
}
