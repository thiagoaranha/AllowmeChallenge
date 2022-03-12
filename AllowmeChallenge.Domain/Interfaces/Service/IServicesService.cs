using AllowmeChallenge.Domain.Entity;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Service
{
    public interface IServicesService : IServiceBase<Services>
    {
        Task<Services> GetWeatherService();
        Task<Services> GetGeolactionService();
    }
}
