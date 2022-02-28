

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinalProject.UI.RequestOperations
{
    public class ApiCallService : IApiCallService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProtectedLocalStorage _localStorage;

        public ApiCallService(IHttpClientFactory httpClientFactory, ProtectedLocalStorage localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _localStorage = localStorage;
        }
        public async Task<HttpResponseMessage> Delete(string url)
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Delete,
           url);

            var token = await _localStorage.GetAsync<string>("token");

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value);

            var response = await client.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
            url);

            var token = await _localStorage.GetAsync<string>("token");

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value);

            var response = await client.SendAsync(request);

            return response;
        }

        public Task<HttpResponseMessage> MakeInActivePut()
        {
            throw new System.NotImplementedException();
        }
    }
}
