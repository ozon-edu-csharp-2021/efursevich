using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseServiceHttpClient
    {
        public Task<MerchandiseRequestStatus> GetInformationAboutMerchandiseRequest(long id, CancellationToken token);

        public Task<MerchandiseRequest> RequestMerchandise(MerchandiseRequestCreationModel creationModel,
            CancellationToken token);
    }
}