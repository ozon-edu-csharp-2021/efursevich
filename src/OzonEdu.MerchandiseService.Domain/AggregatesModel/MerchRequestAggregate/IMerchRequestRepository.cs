using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.SeedWork;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public interface IMerchRequestRepository : IRepository<MerchRequest>
    {
        Task<MerchRequest> GetById(long itemId, CancellationToken _);
        
        Task<MerchRequest> Add(MerchRequestCreationModel request, CancellationToken _);
    }
}