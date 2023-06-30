using Grpc.Net.Client;
using GrpcServer;
using System;

namespace GrpcClient
{
    class Program { 
        
        static async Task Main(string[] args) 
        {
         Random rnd = new Random();
            //var input = new HelloRequest { Name = "Dave" };
            var channel = GrpcChannel.ForAddress("https://localhost:7012");
            var client = new Talk.TalkClient(channel); //it uses the name of the class to create the other name, this WILL cause you problems, make sure your client protos are set to "Client only" on client end

            var input = new ClientIdentifierRequest {ComputerNumber = 45.ToString(), ClientId = 1 };
            var reply = await client.ClientIdentifierAsync(input);
            Console.WriteLine(reply.Message);
            Console.ReadLine();
            //I'm pretty sure that I'll need something like the following lines of code added in, to be able to parse through client host numbers, so we can identify the computer itself for command line purposes
            // need to format protos and services to reflect these write and read lines changes, unsure of how to currently do that
            //Console.WriteLine("Can you send me your local host number?");
            //string computerHostNumber = Console.ReadLine(); 
            //build random number generator for client end; create a config file that will store information, so client can instantly pull it up. 
        }
    }
}






//having server ask client for their own local host number, so server can store and differentiate between other clients
//store information of local host number as variable, assign to each client 