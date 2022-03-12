using System;
using System.Collections.Generic;

namespace AllowmeChallenge.Application.Model
{
    public class BillingsModel
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<BillingSumaryModel> BillingSumarys { get; set; }

    }
}
