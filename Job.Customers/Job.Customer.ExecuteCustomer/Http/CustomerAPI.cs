using Job.Customer.ExecuteCustomer.ExternalServices.Contents;
using Job.Customer.ExecuteCustomer.ExternalServices.HttpRequest;
using Job.Customer.ExecuteCustomer.Interfaces;
using Job.Customer.ExecuteCustomer.Models.Response;
using System.Threading.Tasks;

namespace Job.Customer.ExecuteCustomer.Http
{
    public class CustomerAPI : ICustomerAPI
    {
        private readonly ICustomerAPISettings _customerAPISettings;

        private int timeOut = 360;
        public CustomerAPI(ICustomerAPISettings customerAPISettings)
        {
            _customerAPISettings = customerAPISettings;
        }
        public async ValueTask<CustomersResponse> GetTokenConsigaMaisAsync()
        {
            var result = await HttpRequestFactory.Get(string.Concat(_customerAPISettings.ApiBasePath, _customerAPISettings.ApiPath), timeOut, string.Empty);

            return result.ContentAsType<CustomersResponse>();
        }
    }
}
