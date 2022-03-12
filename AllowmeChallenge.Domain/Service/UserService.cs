using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckCredentials(string username, string password)
        {
            return await _repository.CheckCredentials(username, password);
        }
    }
}
