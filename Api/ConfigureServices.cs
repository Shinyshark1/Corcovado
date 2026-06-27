using Api.Services.DatabaseFile;

namespace Api
{
    public static class ConfigureServices
    {
        public static void InjectServices(this IServiceCollection services) 
        { 
            services.AddScoped<DatabaseFileService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<DatabaseFileRepository>();
        }
    }
}
