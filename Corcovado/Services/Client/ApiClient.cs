using DTO.DatabaseFile;

namespace Corcovado.Services.Client
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string requestUri)
        {
            return await _httpClient.GetFromJsonAsync<T>(requestUri);
        }

        public async Task DeleteAsync(string requestUri)
        {
            var response = await _httpClient.DeleteAsync($"{requestUri}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<TReponse?> PostAsync<TRequest, TReponse>(string requestUri, TRequest body)
        {
            var response = await _httpClient.PostAsJsonAsync(requestUri, body);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TReponse>();
        }
    }
}
