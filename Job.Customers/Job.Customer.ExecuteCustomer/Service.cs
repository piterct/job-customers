using Job.Customer.ExecuteCustomer.Interfaces;
using Job.Customer.ExecuteCustomer.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Job.Customer.ExecuteCustomer
{
    public class Service : IHostedService, IDisposable
    {

        private readonly IJobSettings _jobSettings;
        private readonly ICustomerAPISettings _customerAPISettings;
        private readonly ICustomerAPI _customerAPI;
        private Timer _timer;

        public Service(IJobSettings jobSettings, ICustomerAPISettings customerAPISettings, ICustomerAPI customerAPI)
        {
            _jobSettings = jobSettings;
            _customerAPISettings = customerAPISettings;
            _customerAPI = customerAPI;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _timer = new Timer(
           (e) => ExecuteCustomer(),
           null,
           TimeSpan.Zero,
           TimeSpan.FromMinutes(Convert.ToDouble(_jobSettings.ExecuteInterval)));

            return Task.CompletedTask;

        }

        private async void ExecuteCustomer()
        {
            try
            {
                
            }

            catch (Exception ex)
            {
              
                new LogJobErroModel
                {
                    Mensagem = ex.Message,
                    Area = "Execute Customer",
                    OcorreuEm = DateTime.Now,
                    TipoException = ex.GetType().Name,
                    StackTrace = ex.StackTrace
                });

            }

            finally
            {
                    new LogJobModel { Mensagem = "Job Finished", Area = "Execute Customer", OcorreuEm = DateTime.Now };
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
