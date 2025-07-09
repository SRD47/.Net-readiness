using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductApp.Database
{
    public static class DbConnection
    {
        public static ProductDbContext CreateConnection()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var ConnectionString = configuration.GetSection("ConnectionToDb:ConnectionString").Value;

            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new ProductDbContext(options);
        }
    }
}
