using System.Threading;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseServiceHttpClient
    {
        void GetInformationAboutMerchandiseRequest(CancellationToken token);

        void RequestMerchandise(CancellationToken token);
    }
}