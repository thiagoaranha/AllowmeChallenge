using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllowmeChallenge.Domain.Entity
{
    public class Billings
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime?  EndDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<BillingSumary> BillingSumarys { get; set; }
    }
}
