using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;

namespace AllowmeChallenge.Domain.Service
{
    public class BillingSumaryService : ServiceBase<BillingSumary>, IBillingSumaryService
    {
        public BillingSumaryService(IBillingSumaryRepository repository) : base(repository)
        {
        }
    }
}
