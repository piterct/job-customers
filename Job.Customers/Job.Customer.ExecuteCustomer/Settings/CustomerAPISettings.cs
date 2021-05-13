using Job.Customer.ExecuteCustomer.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Job.Customer.ExecuteCustomer.Settings
{
    public class CustomerAPISettings : ICustomerAPISettings
    {
        private readonly IConfiguration _configuration;
        public CustomerAPISettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiBasePath => _configuration.GetValue<string>("CustomerAPISettings:ApiBasePath");
        public string ApiPath => _configuration.GetValue<string>("CustomerAPISettings:ApiPath");
    }
}
