using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;

namespace AllowmeChallenge.Domain.Service
{
    public class ServiceRequestsService : ServiceBase<ServiceRequests>, IServiceRequestsService
    {
        private readonly IServiceRequestsRepository _repository;

        public ServiceRequestsService(IServiceRequestsRepository repository) : base(repository)
        {
            _repository = repository;
        }


    }
}
