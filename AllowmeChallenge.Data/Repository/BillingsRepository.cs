using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;

namespace AllowmeChallenge.Data.Repository
{
    public class BillingsRepository : RepositoryBase<Billings>, IBillingsRepository
    {
        public BillingsRepository(AllowmeContext context) : base(context)
        {
        }
    }
}
