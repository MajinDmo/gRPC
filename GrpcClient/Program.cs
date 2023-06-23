using Grpc.Net.Client;
using GrpcServer;
using System;

namespace GrpcClient
{
    class Program { 
        
        static async Task Main(string[] args) 
        {
         
            //var input = new HelloRequest { Name = "Dave" };
            var channel = GrpcChannel.ForAddress("https://localhost:7012");
            var client = new Talk.TalkClient(channel); //it uses the name of the class to create the other name, this WILL cause you problems, make sure your client protos are set to "Client only" on client end

            var input = new ClientIdentifierRequest {ComputerNumber = 45.ToString() };
            var reply = await client.ClientIdentifierAsync(input);
            Console.WriteLine(reply.Message);
            Console.ReadLine();
            //build random number generator for client end; create a config file that will store information, so client can instantly pull it up. 
        }
    }
}