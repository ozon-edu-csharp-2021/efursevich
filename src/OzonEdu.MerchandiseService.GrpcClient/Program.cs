using System;
using System.Text.Json;
using Grpc.Core;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

try
{
    var response1 = client.GetInformationAboutMerchandiseRequest(new MerchandiseRequestId { Id = 1});
    Console.WriteLine(new {status = response1.Status});
    var response2 = client.RequestMerchandise(new MerchandiseRequestCreationModel { Size = 46 });
    Console.WriteLine(new {id = response2.Id, status = response2.Status, size = response2.Size});
}
catch (RpcException e)
{
    Console.WriteLine(e);
}
