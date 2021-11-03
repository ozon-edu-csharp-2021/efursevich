using System;
using System.Text.Json.Serialization;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchandiseRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("merchPackageType")]
        public string MerchPackageType  { get; set; }
        
        [JsonPropertyName("clothingSize")]
        public int ClothingSize { get; set; }
        
        [JsonPropertyName("requestStatus")]
        public string RequestStatus { get; set; }
        
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("completedAt")]
        public DateTime CompletedAt { get; set; }
    }
}