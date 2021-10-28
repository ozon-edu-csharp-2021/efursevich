using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class MerchandiseServiceHttpClient : IMerchandiseServiceHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        public MerchandiseServiceHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async void RequestMerchandise(CancellationToken token)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(new { size = 46 }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5000/v1/api/merchandise", stringContent , token);
            string responseBody = await response.Content.ReadAsStringAsync(token);
            Console.WriteLine(responseBody);
        }
        public async void GetInformationAboutMerchandiseRequest(CancellationToken token)
        {
            string responseBody = await _httpClient.GetStringAsync("http://localhost:5000/v1/api/merchandise/1", token);
            Console.WriteLine(responseBody);
        }
    }
}