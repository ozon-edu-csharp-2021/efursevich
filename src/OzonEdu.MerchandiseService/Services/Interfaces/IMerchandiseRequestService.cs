using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseRequestService
    {
        Task<MerchandiseRequest> GetById(long itemId, CancellationToken _);
        
        Task<MerchandiseRequest> Add(MerchandiseRequestCreationModel request, CancellationToken _);
    }
}