using System.Linq;
using Google.Protobuf.WellKnownTypes;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Domain.SeedWork;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Mappings
{
    public static class Mapper
    {
        public static MerchRequestCreationModel Map(MerchRequestCreationModelDTO creationModelDto)
        {
            var clothingSize = Enumeration.GetAll<ClothingSize>().FirstOrDefault(x => x.Name == creationModelDto.ClothingSize);
            var merchType = Enumeration.GetAll<MerchType>().FirstOrDefault(x => x.Name == creationModelDto.MerchType);
            return new MerchRequestCreationModel(clothingSize, merchType, creationModelDto.EmployeeId);
        }
        
        public static MerchRequestCreationModelDTO Map(MerchRequestCreationModelGrpc creationModelGrpc)
        {
            return new MerchRequestCreationModelDTO
            {
                ClothingSize = creationModelGrpc.ClothingSize,
                MerchType = creationModelGrpc.MerchType,
                EmployeeId = creationModelGrpc.EmployeeId
            };
        }
        
        public static MerchRequestDTO MerchRequestToDTO(MerchRequest merchRequest)
        {
            return new MerchRequestDTO
            {
                Id = merchRequest.Id,
                ClothingSize = merchRequest.ClothingSize.Name,
                MerchType = merchRequest.MerchType.Name,
                EmployeeId = merchRequest.EmployeeId,
                CreatedAt = merchRequest.CreatedAt,
                RequestStatus = merchRequest.RequestStatus.Name
            };
        }

        public static MerchRequestGrpc MerchRequestToGrpc(MerchRequest merchRequest)
        {
            return new MerchRequestGrpc
            {
                Id = merchRequest.Id,
                ClothingSize = merchRequest.ClothingSize.Name,
                MerchType = merchRequest.MerchType.Name,
                RequestStatus = merchRequest.RequestStatus.Name,
                CreatedAt = Timestamp.FromDateTime(merchRequest.CreatedAt),
                CompletedAt = Timestamp.FromDateTime(merchRequest.CompletedAt)
            };
        }
    }
}