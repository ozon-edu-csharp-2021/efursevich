using System.Text.Json.Serialization;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchandiseRequestCreationModel
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("merchPackageType")]
        public string MerchPackageType  { get; set; }
        
        [JsonPropertyName("clothingSize")]
        public int ClothingSize { get; set; }
    }
}