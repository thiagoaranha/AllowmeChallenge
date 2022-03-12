using AllowmeChallenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Service
{
    public interface IBillingsService : IServiceBase<Billings>
    {
        Task<Billings> CreateBilling(DateTime startDate, DateTime endDate);
        IEnumerable<BillingSumary> GetBillingsSumary(IEnumerable<ServiceRequests> serviceRequests);
    }
}
