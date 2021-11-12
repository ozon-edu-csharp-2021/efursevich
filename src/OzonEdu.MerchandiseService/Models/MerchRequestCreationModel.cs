using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchRequestCreationModel
    {
        public ClothingSize ClothingSize { get; }
        public MerchType MerchType { get; }
        public long EmployeeId { get; }

        public MerchRequestCreationModel(ClothingSize clothingSize, MerchType merchType, long employeeId)
        {
            ClothingSize = clothingSize;
            MerchType = merchType;
            EmployeeId = employeeId;
        }
    }
}