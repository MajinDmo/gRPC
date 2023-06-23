using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var input = new HelloRequest { Name = "Sam" };
            var channel = GrpcChannel.ForAddress("https://localhost:7012");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(input);
            Console.WriteLine(reply.Message);
            Console.ReadLine();
        }
    }
}

