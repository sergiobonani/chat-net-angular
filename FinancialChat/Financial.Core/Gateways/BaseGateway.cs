using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Financial.Core.Gateways
{
    public abstract class BaseGateway<T>
    {
        protected ILogger<T> _logger;

        public BaseGateway(ILogger<T> logger)
        {
            _logger = logger;
        }

        public virtual async Task<TResponse> GetRequest<TResponse>(string url)
        {
            var responseContent = string.Empty;

            try
            {
                //using var client = GetClient(clientName);
                using var client = new HttpClient();

                var clientResponse = await client.GetAsync(url);
                responseContent = await clientResponse.Content.ReadAsStringAsync();

                if (typeof(TResponse).IsValueType)
                {
                    return JsonSerializer.Deserialize<TResponse>(responseContent);
                }

                return (TResponse)(object)responseContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error {Url}: {ResponseContent}", url, responseContent);
                throw;
            }
        }
        public virtual async Task PostRequest<TRequest>(string url, TRequest contentMessage)
        {
            var responseContent = string.Empty;

            try
            {
                //using var client = GetClient(clientName);
                var json = JsonSerializer.Serialize(contentMessage);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = new HttpClient();

                var clientResponse = await client.PostAsync(url, content);
                responseContent = await clientResponse.Content.ReadAsStringAsync();
                clientResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error {Url}: {ResponseContent}", url, responseContent);
                throw;
            }
        }
    }
}
