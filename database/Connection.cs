using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace database
{
    public static class Connection
    {
        //Inits IConfig to get string values from appsettings.json and configures NPGSQL to use CS from appsettings.
        private static IConfigurationRoot _configuration;

        private static void Init()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public static void ConnectToDb(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Init();
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));
            }
        }

        public static string GetSecret()
        {
            Init();
            return _configuration.GetConnectionString("Default");
        }
        public static string GetJwtSecret()
        {
            Init();
            return _configuration["JWT:Secret"];
        }
        public static string GetJwtIssuer()
        {
            Init();
            return _configuration["JWT:ValidIssuer"];
        }
    }
}