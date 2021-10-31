using System.Text.Json.Serialization;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchandiseRequestCreationModel
    {
        [JsonPropertyName("size")]
        public int Size { get; }
    }
}