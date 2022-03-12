using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AllowmeChallenge.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AllowmeContext context) : base(context)
        {
        }

        public async Task<bool> CheckCredentials(string username, string password)
        {
            var user = await _context.User.Where(u => u.Username.ToLower() == username.ToLower() && u.Password == password).FirstOrDefaultAsync();
            return user != null;
        }
    }
}
