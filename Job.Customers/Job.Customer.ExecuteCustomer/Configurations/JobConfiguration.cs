using Job.Customer.ExecuteCustomer.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Job.Customer.ExecuteCustomer.Configurations
{
    public class JobConfiguration : IJobConfiguration
    {
        private readonly IConfiguration _configuration;

        public JobConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ExecuteInterval => _configuration.GetValue<string>("JobConfiguration:ExecuteInterval");
    }
}
