
using AllowmeChallenge.Application.Configuration;
using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Interfaces.Service;
using AllowmeChallenge.Recurring.ExternalServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AllowmeChallenge.Recurring
{
    public class AllowmeChallengeJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (String.IsNullOrWhiteSpace(environment))
                throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            Console.WriteLine("Environment: {0}", environment);

            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            if (environment == "Development")
            {

                builder
                    .AddJsonFile(
                        Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{environment}.json"),
                        optional: true
                    );
            }
            else
            {
                builder
                    .AddJsonFile($"appsettings.{environment}.json", optional: false);
            }

            var configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.ResolveDependencies();
            serviceCollection.AddAutoMapper(typeof(AutomapperConfig));
            serviceCollection.AddDbContext<AllowmeContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = serviceCollection.BuildServiceProvider();


            var weatherApiService = new WeatherApiService(serviceProvider.GetService<IMapper>(),
                                                            serviceProvider.GetService<ILogger>(),
                                                            serviceProvider.GetService<IServicesService>(),
                                                            serviceProvider.GetService<IServiceRequestsService>());
            await weatherApiService.CheckRecifeWeather();
            await weatherApiService.CheckSaoPauloWeather();
        }
    }
}
