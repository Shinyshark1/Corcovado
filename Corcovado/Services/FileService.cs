using Corcovado.Services.Client;
using DTO.DatabaseFile;

namespace Corcovado.Services
{
    public class FileService
    {
        private readonly IApiClient _client;

        private const string DatabaseFileControllerEndpoint = "DatabaseFile";

        public FileService(IApiClient client)
        {
            _client = client;
        }

        public async Task<List<DatabaseFileDTO>> GetDatabaseFiles()
        {
            var response = await _client.GetAsync<List<DatabaseFileDTO>>(DatabaseFileControllerEndpoint);
            return response ?? [];
        }

        public async Task DeleteDatabaseFile(int databaseFileId)
        {
            await _client.DeleteAsync($"{DatabaseFileControllerEndpoint}/{databaseFileId}");
        }
    }
}
