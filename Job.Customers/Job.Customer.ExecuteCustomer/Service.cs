using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Job.Customer.ExecuteCustomer
{
    public class Service : IHostedService, IDisposable
    {


        private Timer _timer;

        public Service()
        {
           
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _timer = new Timer(
           (e) => ExecuteCustomer(),
           null,
           TimeSpan.Zero,
           TimeSpan.FromMinutes(Convert.ToDouble(20)));

            return Task.CompletedTask;

        }

        private async void ExecuteCustomer()
        {
           
           
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
