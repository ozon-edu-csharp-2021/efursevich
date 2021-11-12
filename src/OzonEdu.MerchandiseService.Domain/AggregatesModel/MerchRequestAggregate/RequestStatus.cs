using OzonEdu.MerchandiseService.Domain.SeedWork;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus Submitted = new(1, nameof(Submitted));
        public static RequestStatus NotEnoughRequiredItems = new(2, nameof(NotEnoughRequiredItems));
        public static RequestStatus StockConfirmed = new(3, nameof(StockConfirmed)); 
        public static RequestStatus Completed = new(4, nameof(Completed)); 
        
        public RequestStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}