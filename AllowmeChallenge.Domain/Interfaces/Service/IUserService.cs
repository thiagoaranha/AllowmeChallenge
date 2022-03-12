using AllowmeChallenge.Domain.Entity;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Service
{
    public interface IUserService : IServiceBase<User>
    {
        Task<bool> CheckCredentials(string username, string password);
    }
}
