using AllowmeChallenge.Data.Repository;
using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;
using AllowmeChallenge.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AllowmeChallenge.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            //Service
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IServiceRequestsService, ServiceRequestsService>();
            services.AddTransient<IBillingsService, BillingsService>();
            services.AddTransient<IBillingSumaryService, BillingSumaryService>();
            services.AddTransient<IUserService, UserService>();

            //Repository
            services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<IServiceRequestsRepository, ServiceRequestsRepository>();
            services.AddTransient<IBillingsRepository, BillingsRepository>();
            services.AddTransient<IBillingSumaryRepository, BillingSumaryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
