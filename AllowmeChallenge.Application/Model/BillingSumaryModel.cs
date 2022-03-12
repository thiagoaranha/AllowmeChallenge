using System;

namespace AllowmeChallenge.Application.Model
{
    public class BillingSumaryModel
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public long BillingId { get; set; }
        public long ServiceId { get; set; }
        public int TotalRequests { get; set; }
        public decimal PricePerRequest { get; set; }

    }
}
