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
(CustomerLookupModel request, ServerCallContext context)
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
        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
            new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Corey",
                EmailAddress = "tim@iamtimcorey.com",
                Age = 41,
                IsAlive = true,
            },
            new CustomerModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                EmailAddress = "sue.stormy.net",
                Age = 28,
                IsAlive = false,
            },
             new CustomerModel
             {
                 FirstName = "Bilbo",
                 LastName = "Baggins",
                 EmailAddress = "bilbo.middleearth.net",
                 Age = 117,
                 IsAlive = false,
             },
        };
    
            foreach (var cust in customers)
            {
                await responseStream.WriteAsync(cust);
            }
        
            
        } //once we hit this curly bracket, server will stop listening to the stream
    }
}
