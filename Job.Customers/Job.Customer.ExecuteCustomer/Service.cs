using Job.Customer.ExecuteCustomer.Interfaces;
using Job.Customer.ExecuteCustomer.Models;
using Job.Customer.ExecuteCustomer.Models.Response;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Job.Customer.ExecuteCustomer
{
    public class Service : IHostedService, IDisposable
    {

        private readonly IJobConfiguration _jobConfiguration;
        private readonly ICustomerAPI _customerAPI;
        private Timer _timer;

        public Service(IJobConfiguration jobConfiguration, ICustomerAPI customerAPI)
        {
            _jobConfiguration = jobConfiguration;
            _customerAPI = customerAPI;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _timer = new Timer(
           (e) => ExecuteCustomer(),
           null,
           TimeSpan.Zero,
           TimeSpan.FromMinutes(Convert.ToDouble(_jobConfiguration.ExecuteInterval)));

            return Task.CompletedTask;

        }

        private async void ExecuteCustomer()
        {
            try
            {
                CustomersResponse customers = await _customerAPI.GetCustomers();
            }

            catch (Exception ex)
            {

                new LogJobErrorModel
                {
                    Message = ex.Message,
                    Area = "Execute Customer",
                    Date = DateTime.Now,
                    TypeException = ex.GetType().Name,
                    StackTrace = ex.StackTrace
                };

            }

            finally
            {
                new LogJobModel { Message = "Job Finished", Area = "Execute Customer", Date = DateTime.Now };
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
