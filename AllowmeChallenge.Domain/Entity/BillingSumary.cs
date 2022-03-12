using System;
using System.ComponentModel.DataAnnotations;

namespace AllowmeChallenge.Domain.Entity
{
    public class BillingSumary
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public long BillingId { get; set; }
        public long ServiceId { get; set; }
        public int TotalRequests { get; set; }
        public decimal PricePerRequest { get; set; }

        public Services Service { get; set; }
        public Billings Billing { get; set; }
    }
}
