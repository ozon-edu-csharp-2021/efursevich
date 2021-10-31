using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService: MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseRequestService _merchandiseRequestService;

        public MerchandiseGrpcService(IMerchandiseRequestService merchandiseRequestService)
        {
            _merchandiseRequestService = merchandiseRequestService;
        }
        public override async Task<MerchandiseRequestStatus> GetInformationAboutMerchandiseRequest(
            MerchandiseRequestId request,
            ServerCallContext context)
        {
            var merchandiseRequest = await _merchandiseRequestService.GetById(request.Id, context.CancellationToken);
            return new MerchandiseRequestStatus {Status = merchandiseRequest.Status};
        }

        public override async Task<MerchandiseRequest> RequestMerchandise(MerchandiseRequestCreationModel request, 
            ServerCallContext context)
        {
            var merchandiseRequest = await _merchandiseRequestService.Add(new(request.Size), 
                context.CancellationToken);
            return new MerchandiseRequest
            {
                Id = merchandiseRequest.Id,
                Status = merchandiseRequest.Status,
                Size = merchandiseRequest.Size
            };
        }
    }
}