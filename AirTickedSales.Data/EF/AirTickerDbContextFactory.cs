using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AirTickedSales.Data.EF
{
    public class AirTickerDbContextFactory : IDesignTimeDbContextFactory<AirTickedSaleDbContext>
    {
        public AirTickedSaleDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuration.GetConnectionString("airTickketSalesDb");

            var optionsBuilder = new DbContextOptionsBuilder<AirTickedSaleDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AirTickedSaleDbContext(optionsBuilder.Options);
        }
    }
}
