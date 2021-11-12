using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Mappings;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService: MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchRequestService _merchRequestService;

        public MerchandiseGrpcService(IMerchRequestService merchRequestService)
        {
            _merchRequestService = merchRequestService;
        }
        
        public override async Task<MerchRequestGrpc> GetInfoAboutMerchRequest(Int64Value id, ServerCallContext context)
        {
            var request = await _merchRequestService.GetById(id.Value, context.CancellationToken);
            if (request is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Request with id={id} does not exist"));
            }
            var merchRequestGrpc = Mapper.MerchRequestToGrpc(request);
            return merchRequestGrpc;
        }

        public override async Task<MerchRequestGrpc> RequestMerchandise(MerchRequestCreationModelGrpc creationModelGrpc, 
            ServerCallContext context)
        {
            var creationModelDTO = Mapper.Map(creationModelGrpc);
            var creationModel = Mapper.Map(creationModelDTO);
            if (creationModel.ClothingSize is null || creationModel.MerchType is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"Invalid ClothingSize or MerchType"));
            }
            var request = await _merchRequestService.Add(creationModel, context.CancellationToken);
            var merchRequestGrpc = Mapper.MerchRequestToGrpc(request);
            return merchRequestGrpc;
        }
    }
}