using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Service
{
    public class ServicesService : ServiceBase<Services>, IServicesService
    {
        private readonly IServicesRepository _repository;

        public ServicesService(IServicesRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Services> GetWeatherService()
        {
            return await _repository.GetWeatherService();
        }

        public async Task<Services> GetGeolactionService()
        {
            return await _repository.GetGeolactionService();
        }
    }
}
