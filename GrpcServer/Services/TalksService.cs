using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
    public class TalksService : Talk.TalkBase
    {
        private readonly ILogger<TalksService> _logger;
        public TalksService(ILogger<TalksService> logger)
        {
            _logger = logger;
        }

        public override Task<ClientIdentifierResponse> ClientIdentifier(ClientIdentifierRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ClientIdentifierResponse
            {
                Message = "Hello, your computer number is: " + request.ComputerNumber
                
            }) ;
        }
    }
}