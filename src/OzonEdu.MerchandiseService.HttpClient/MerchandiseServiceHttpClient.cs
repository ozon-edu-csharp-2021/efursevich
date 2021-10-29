using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class MerchandiseServiceHttpClient : IMerchandiseServiceHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseServiceHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchandiseRequestStatus> GetInformationAboutMerchandiseRequest(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("v1/api/merchandise/1", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchandiseRequestStatus>(body);
        }
        
        public async Task<MerchandiseRequest> RequestMerchandise(CancellationToken token)
        {
            string jsonContent = JsonSerializer.Serialize(new {size = 46});
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/v1/api/merchandise", content, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchandiseRequest>(body);
        }
    }
}