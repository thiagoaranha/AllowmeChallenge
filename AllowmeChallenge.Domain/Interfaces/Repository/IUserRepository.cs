using AllowmeChallenge.Domain.Entity;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> CheckCredentials(string username, string password);

    }
}
