using DTO.DatabaseFile;

namespace Corcovado.Services
{
    public class ApiHttpClient
    {
        private readonly HttpClient _httpClient;

        public ApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DatabaseFileDTO>> GetDatabaseFilesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DatabaseFileDTO>>("DatabaseFile") ?? [];
        }
    }
}
