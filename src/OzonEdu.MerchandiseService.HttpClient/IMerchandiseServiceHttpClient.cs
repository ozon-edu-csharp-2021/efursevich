using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseServiceHttpClient
    {
        public Task<MerchandiseRequestStatus> GetInformationAboutMerchandiseRequest(CancellationToken token);

        public Task<MerchandiseRequest> RequestMerchandise(CancellationToken token);
    }
}