using Api.Services.DatabaseFile;

namespace Api
{
    public static class ConfigureServices
    {
        public static void InjectServices(this IServiceCollection services) 
        { 
        
        }

        public static void InjectProviders(this IServiceCollection services)
        {
            services.AddScoped<DatabaseFileProvider>();
        }
    }
}
