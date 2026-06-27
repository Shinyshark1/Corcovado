using Corcovado.Services.Client;

namespace Corcovado.Services.Configuration
{
    public static class ConfigureServices
    {
        public static void InjectHttpClient(this IServiceCollection services, string baseAddress)
        {
            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<FileService>();
        }
    }
}
