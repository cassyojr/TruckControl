using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.DbConfig
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure");

                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();

                return Configuration;
            }
        }

        public static string GetConnection()
        {
            return ConnectionConfiguration.GetConnectionString("ContextConnection");
        }
    }
}
