using System;
using System.ComponentModel.DataAnnotations;

namespace AllowmeChallenge.Domain.Entity
{
    public class ServiceRequests
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long ServiceId { get; set; }
        public int StatusCode { get; set; }
        public Services Service { get; set; }
    }
}
