using System.Net.Http.Headers;
using System.Text.Json;

namespace DiscordBot_Web.HttpClient
{
    public class GatewayHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GatewayHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Headers.Clear();
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(responseStream);
            }
            else
            {
                throw new BadHttpRequestException(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);
            }
        }
    }
}
