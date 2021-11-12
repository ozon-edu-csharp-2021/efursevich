using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Mappings;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService: MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public MerchandiseGrpcService(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }
        
        public override async Task<MerchRequestGrpc> GetInfoAboutMerchRequest(Int64Value id, ServerCallContext context)
        {
            var request = await _merchRequestRepository.GetById(id.Value, context.CancellationToken);
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
            var request = await _merchRequestRepository.Add(creationModel, context.CancellationToken);
            var merchRequestGrpc = Mapper.MerchRequestToGrpc(request);
            return merchRequestGrpc;
        }
    }
}