using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase //hightlight CustomerBase and hit F12 to access developer file
    {
        private readonly ILogger<CustomersService> _logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo
(CustomerLookupModel request,ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "David";
                output.LastName = "Moses";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Genna";
                output.LastName = "Mitchell";
            }
            else
            {
                output.FirstName = "Lex";
                output.LastName = "Xel";

            }
                return Task.FromResult(output);
        }

    }
}
