using System.Threading;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class Program
    {
        static void Main()
        {
            IMerchandiseServiceHttpClient client = new MerchandiseServiceHttpClient(new System.Net.Http.HttpClient());
            client.RequestMerchandise(CancellationToken.None);
            client.GetInformationAboutMerchandiseRequest(CancellationToken.None);
        }
    }
}