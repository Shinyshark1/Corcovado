namespace Corcovado.Services.Client
{
    public interface IApiClient
    {
        Task DeleteAsync(string requestUri);
        Task<T?> GetAsync<T>(string requestUri);
        Task<TReponse?> PostAsync<TRequest, TReponse>(string requestUri, TRequest body);
    }
}