using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseServiceHttpClient
    {
        public Task<MerchRequestDTO> GetInfoAboutMerchRequest(long id, CancellationToken token);

        public Task<MerchRequestDTO> RequestMerchandise(MerchRequestCreationModelDTO creationModel, CancellationToken token);
    }
}