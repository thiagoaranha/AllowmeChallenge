using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Service
{
    public class BillingsService : ServiceBase<Billings>, IBillingsService
    {
        private readonly IBillingsRepository _billingsRepository;
        private readonly IServiceRequestsRepository _serviceRequestsRepository;

        public BillingsService(IBillingsRepository billingsRepository,
                                IServiceRequestsRepository serviceRequestsRepository) : base(billingsRepository)
        {
            _billingsRepository = billingsRepository;
            _serviceRequestsRepository = serviceRequestsRepository;
        }

        public async Task<Billings> CreateBilling(DateTime startDate, DateTime endDate)
        {
            var serviceRequests = await _serviceRequestsRepository.Get(startDate, endDate);
            var billingsSumary = GetBillingsSumary(serviceRequests);

            var billing = new Billings()
            {
                CreatedAt = DateTime.Now,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = billingsSumary.Sum(b => b.PricePerRequest * b.TotalRequests),
                BillingSumarys = billingsSumary.ToList()
            };

            if(billing.TotalPrice > 0)
                await _billingsRepository.AddAsync(billing);

            return billing;
        }

        public IEnumerable<BillingSumary> GetBillingsSumary(IEnumerable<ServiceRequests> serviceRequests)
        {
            var billingsSumary = new List<BillingSumary>();

            var requestsGroupByService = serviceRequests.GroupBy(s => s.ServiceId);

            foreach (var requestsGroup in requestsGroupByService)
            {
                var firstService = requestsGroup.FirstOrDefault().Service;
                var billingSumary = new BillingSumary()
                {
                    CreatedAt = DateTime.Now,
                    ServiceId = firstService.Id,
                    PricePerRequest = firstService.PricePerRequest,
                    TotalRequests = requestsGroup.Count()
                };

                billingsSumary.Add(billingSumary);
            }

            return billingsSumary;
        }


    }
}
