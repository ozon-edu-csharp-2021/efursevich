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
        public async Task<MerchRequestDTO> GetInfoAboutMerchRequest(long id, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"/v1/api/merchandise/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchRequestDTO>(body);
        }
        
        public async Task<MerchRequestDTO> RequestMerchandise(MerchRequestCreationModelDTO creationModel, CancellationToken token)
        {
            string jsonContent = JsonSerializer.Serialize(creationModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/v1/api/merchandise", content, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchRequestDTO>(body);
        }
    }
}