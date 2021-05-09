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
        private static async Task  Main(string[] args)
        {

            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            var config = LoadConfiguration();

            var builder = new HostBuilder()
           .ConfigureServices((hostContext, services) =>
           {
               services.AddHostedService<Service>();
               services.AddSingleton(config);
               //services.AddSingleton<IJobProcessarPropostaSettings, JobProcessarPropostaSettings>();
               //services.AddSingleton<IConsigaMaisSettings, ConsigaMaisSettings>();
               //services.AddScoped<IConsigaMaisAPI, ConsigaMaisAPI>();
               //services.AddApplicationInsightsTelemetryWorkerService();
               //services.AddSingleton<IApplicationInsightsService, ApplicationInsightsService>();
               //services.AddSingleton<IApplicationInsightsSettings, ApplicationInsightsSettings>();

           });
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
