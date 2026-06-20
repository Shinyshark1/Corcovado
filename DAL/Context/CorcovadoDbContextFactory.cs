using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.Context
{
    public class CorcovadoDbContextFactory : IDesignTimeDbContextFactory<CorcovadoDbContext>
    {
        public CorcovadoDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CorcovadoDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("CorcovadoDatabase"));    

            return new CorcovadoDbContext(optionsBuilder.Options);
        }
    }
}
