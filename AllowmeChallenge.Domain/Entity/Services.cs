using System.ComponentModel.DataAnnotations;

namespace AllowmeChallenge.Domain.Entity
{
    public class Services
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Endpoint { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public decimal PricePerRequest { get; set; }

    }
}
