using System.Text.Json.Serialization;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchandiseRequestStatus
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}