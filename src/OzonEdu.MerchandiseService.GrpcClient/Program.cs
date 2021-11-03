using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

try
{
    var int64Value = new Int64Value { Value = 3 };
    var response1 = client.GetInformationAboutMerchandiseRequest(int64Value);
    Console.WriteLine(response1);
    var creationModel = new MerchandiseRequestCreationModelGrpc
    {
        FirstName = "Валерий",
        LastName = "Кролов",
        ClothingSize = 46,
        MerchPackageType = "Full"
    };
    var response2 = client.RequestMerchandise(creationModel);
    Console.WriteLine(response2);
}
catch (RpcException e)
{
    Console.WriteLine(e);
}
