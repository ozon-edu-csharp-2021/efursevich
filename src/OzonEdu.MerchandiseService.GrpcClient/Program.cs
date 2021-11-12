using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

try
{
    var int64Value = new Int64Value { Value = 8 };
    var response1 = client.GetInfoAboutMerchRequest(int64Value);
    Console.WriteLine(response1);
}
catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound || ex.StatusCode == StatusCode.InvalidArgument)
{
    Console.WriteLine(ex.Message);
}
catch (RpcException ex)
{
    Console.WriteLine(ex);
}

try
{
    var creationModel = new MerchRequestCreationModelGrpc
    {
        ClothingSize = "ClothingSize.L.Name",
        MerchType = MerchType.VeteranPack.Name,
        EmployeeId = 1
    };
    var response2 = client.RequestMerchandise(creationModel);
    Console.WriteLine(response2);
}
catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound || ex.StatusCode == StatusCode.InvalidArgument)
{
    Console.WriteLine(ex.Message);
}
catch (RpcException ex)
{
    Console.WriteLine(ex);
}