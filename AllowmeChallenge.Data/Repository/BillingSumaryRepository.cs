using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;

namespace AllowmeChallenge.Data.Repository
{
    public class BillingSumaryRepository : RepositoryBase<BillingSumary>, IBillingSumaryRepository
    {
        public BillingSumaryRepository(AllowmeContext context) : base(context)
        {
        }
    }
}
