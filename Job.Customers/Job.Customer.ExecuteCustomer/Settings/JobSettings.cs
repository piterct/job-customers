

using Microsoft.Extensions.Configuration;

namespace Job.Customer.ExecuteCustomer.Settings
{
    public class JobSettings
    {
        private readonly IConfiguration _configuration;

        public JobSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ExecuteInterval => _configuration.GetValue<string>("JobSettings:ExecuteInterval");
    }
}
