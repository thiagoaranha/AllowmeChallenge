using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using System.Threading.Tasks;

namespace AllowmeChallenge.Data.Repository
{
    public class ServicesRepository : RepositoryBase<Services>, IServicesRepository
    {
        private readonly long _weatherServiceId = 1;
        private readonly long _geolactionServiceId = 2;


        public ServicesRepository(AllowmeContext context) : base(context)
        {
        }

        public async Task<Services> GetWeatherService()
        {
            return await _context.Services.FindAsync(_weatherServiceId);
        }

        public async Task<Services> GetGeolactionService()
        {
            return await _context.Services.FindAsync(_geolactionServiceId);
        }

    }
}
