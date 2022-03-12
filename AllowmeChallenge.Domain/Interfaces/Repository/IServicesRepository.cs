using AllowmeChallenge.Domain.Entity;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Repository
{
    public interface IServicesRepository : IRepositoryBase<Services>
    {
        Task<Services> GetWeatherService();
        Task<Services> GetGeolactionService();
    }
}
