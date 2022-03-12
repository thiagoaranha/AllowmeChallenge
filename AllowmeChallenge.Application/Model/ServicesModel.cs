namespace AllowmeChallenge.Application.Model
{
    public class ServicesModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Endpoint { get; set; }

        public string Path { get; set; }

        public decimal PricePerRequest { get; set; }
    }
}
