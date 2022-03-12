using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllowmeChallenge.Data.Repository
{
    public class ServiceRequestsRepository : RepositoryBase<ServiceRequests>, IServiceRequestsRepository
    {
        public ServiceRequestsRepository(AllowmeContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ServiceRequests>> Get(DateTime startDate, DateTime endDate)
        {
            return await _context.ServiceRequests
                                    .Where(s => startDate <= s.CreatedAt && s.CreatedAt <= endDate)
                                    .Include(s => s.Service)
                                    .ToListAsync();
        }
    }
}
