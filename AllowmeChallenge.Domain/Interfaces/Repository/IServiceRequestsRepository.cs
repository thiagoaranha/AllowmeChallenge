using AllowmeChallenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Repository
{
    public interface IServiceRequestsRepository : IRepositoryBase<ServiceRequests>
    {
        Task<IEnumerable<ServiceRequests>> Get(DateTime startDate, DateTime endDate);
    }
}
