using System.Text.Json.Serialization;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchRequestCreationModelDTO
    {
        [JsonPropertyName("clothingSize")]
        public string ClothingSize { get; set; }
        
        [JsonPropertyName("merchType")]
        public string MerchType { get; set; }
        
        [JsonPropertyName("employeeId")]
        public long EmployeeId { get; set; }
    }
}