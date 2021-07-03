using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace database
{
    public static class Connection
    {
        public static void ConnectToDb(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath("/")
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));
            }
        }
    }
}