using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCorcovadoDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CorcovadoDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        connectionString, 
                        sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null);

                            sqlOptions.MigrationsAssembly(typeof(CorcovadoDbContext).Assembly.FullName);
                        });
                }, ServiceLifetime.Scoped);
            
            return services;
        }

        public static void ApplyDatabaseMigrations(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CorcovadoDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
