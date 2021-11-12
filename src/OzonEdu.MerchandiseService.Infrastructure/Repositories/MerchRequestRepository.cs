using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchRequestRepository : IMerchRequestRepository
    {
        public readonly List<MerchRequest> MerchRequests = new()
        {
            new MerchRequest(1,ClothingSize.XS, MerchType.WelcomePack, 1),
            new MerchRequest(2,ClothingSize.S, MerchType.ProbationPeriodEndingPack, 2),
            new MerchRequest(3,ClothingSize.M, MerchType.ConferenceListenerPack, 3),
            new MerchRequest(4,ClothingSize.L, MerchType.ConferenceSpeakerPack, 4),
            new MerchRequest(5,ClothingSize.XL, MerchType.VeteranPack, 5),
        };

        public Task<MerchRequest> GetById(long id, CancellationToken _)
        {
            var request = MerchRequests.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(request);
        }

        public Task<MerchRequest> Add(MerchRequestCreationModel creationModel, CancellationToken _)
        {
            long id = MerchRequests.Max(x => x.Id) + 1;
            var merchRequest = new MerchRequest(id, creationModel.ClothingSize, creationModel.MerchType, creationModel.EmployeeId);
            MerchRequests.Add(merchRequest);
            return Task.FromResult(merchRequest);
        }
    }
}