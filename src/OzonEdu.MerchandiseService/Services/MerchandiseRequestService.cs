using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseRequestService : IMerchandiseRequestService
    {
        private readonly List<MerchandiseRequest> MerchandiseRequests = new List<MerchandiseRequest>
        {
            new MerchandiseRequest(1, "Исполнен", 44),
            new MerchandiseRequest(2, "В обработке", 46),
            new MerchandiseRequest(3, "Создан", 48)
        };

        public Task<MerchandiseRequest> GetById(long id, CancellationToken _)
        {
            var request = MerchandiseRequests.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(request);
        }

        public Task<MerchandiseRequest> Add(MerchandiseRequestCreationModel model, CancellationToken _)
        {
            long id = MerchandiseRequests.Max(x => x.Id) + 1;
            string status = "Создан";
            var newMerchandiseRequest = new MerchandiseRequest(id, status, model.Size);
            MerchandiseRequests.Add(newMerchandiseRequest);
            return Task.FromResult(newMerchandiseRequest);
        }
    }
}