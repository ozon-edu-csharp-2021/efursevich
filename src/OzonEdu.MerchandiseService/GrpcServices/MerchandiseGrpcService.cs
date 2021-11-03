using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Models;
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
        
        public override async Task<MerchandiseRequestStatusGrpc> GetInformationAboutMerchandiseRequest(Int64Value id, 
            ServerCallContext context)
        {
            var request = await _merchandiseRequestService.GetById(id.Value, context.CancellationToken);
            return new MerchandiseRequestStatusGrpc
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MerchPackageType = request.MerchPackageType,
                ClothingSize = request.ClothingSize,
                RequestStatus = request.RequestStatus,
                CreatedAt = Timestamp.FromDateTime(request.CreatedAt),
                CompletedAt = Timestamp.FromDateTime(request.CompletedAt)
            };
        }

        public override async Task<MerchandiseRequestGrpc> RequestMerchandise(MerchandiseRequestCreationModelGrpc model, 
            ServerCallContext context)
        {
            var creationModel = new MerchandiseRequestCreationModel(model.FirstName, model.LastName, 
                model.MerchPackageType, model.ClothingSize);
            var request = await _merchandiseRequestService.Add(creationModel, context.CancellationToken);
            return new MerchandiseRequestGrpc
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MerchPackageType = request.MerchPackageType,
                ClothingSize = request.ClothingSize,
                RequestStatus = request.RequestStatus,
                CreatedAt = Timestamp.FromDateTime(request.CreatedAt),
                CompletedAt = Timestamp.FromDateTime(request.CompletedAt)
            };
        }
    }
}