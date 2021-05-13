using Job.Customer.ExecuteCustomer.Configurations;
using Job.Customer.ExecuteCustomer.Http;
using Job.Customer.ExecuteCustomer.Interfaces;
using Job.Customer.ExecuteCustomer.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Job.Customer.ExecuteCustomer
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {

            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            var config = LoadConfiguration();

            var builder = new HostBuilder()
           .ConfigureServices((hostContext, services) =>
           {
               services.AddHostedService<Service>();
               services.AddSingleton(config);
               services.AddSingleton<IJobConfiguration, JobConfiguration>();
               services.AddSingleton<ICustomerAPISettings, CustomerAPISettings>();
               services.AddScoped<ICustomerAPI, CustomerAPI>();

           });

            if (isService)
            {
                await builder.RunAsServiceAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json");

            return builder.Build();

        }
    }
}
