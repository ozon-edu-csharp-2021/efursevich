using System;
using System.Text.Json.Serialization;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchRequestDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("clothingSize")]
        public string ClothingSize { get; set; }
        
        [JsonPropertyName("merchType")]
        public string MerchType  { get; set; }
        
        [JsonPropertyName("employeeId")]
        public long EmployeeId { get; set; }
        
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("requestStatus")]
        public string RequestStatus { get; set; }
    }
}