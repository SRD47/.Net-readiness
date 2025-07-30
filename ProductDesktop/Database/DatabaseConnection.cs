using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ProductDesktop.Database
{
    public class DatabaseConnection
    {
        public DatabaseContext CreateConnection()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetSection("DbConnection:ConnectionString").Value; 

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new DatabaseContext(options);
        }
    }
}
