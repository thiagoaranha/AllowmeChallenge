using System;

namespace AllowmeChallenge.Application.Model
{
    public class ServiceRequestsModel
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long ServiceId { get; set; }
        public int StatusCode { get; set; }
    }
}
