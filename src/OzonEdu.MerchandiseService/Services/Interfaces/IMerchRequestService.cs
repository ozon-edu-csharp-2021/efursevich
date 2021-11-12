using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchRequestService
    {
        Task<MerchRequest> GetById(long itemId, CancellationToken _);
        
        Task<MerchRequest> Add(MerchRequestCreationModel request, CancellationToken _);
    }
}