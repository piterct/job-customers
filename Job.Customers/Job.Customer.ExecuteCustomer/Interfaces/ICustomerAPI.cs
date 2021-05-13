using Job.Customer.ExecuteCustomer.Models.Response;
using System.Threading.Tasks;

namespace Job.Customer.ExecuteCustomer.Interfaces
{
    public interface  ICustomerAPI
    {
        ValueTask<CustomersResponse> GetCustomers();
    }
}
