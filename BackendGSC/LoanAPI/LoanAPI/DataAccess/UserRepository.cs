using LoadApi.DataAccess;
using LoadApi.Entities;
using LoanAPI.Dto;
using LoanAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.DataAccess
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LoanContext context)
            : base(context)
        {
        }

        public Task<User?> GetByUsernamePassword(UserDto user)
        {

            var result = dbSet
                .Where(u => u.UserName == user.UserName)
                .SingleOrDefaultAsync();
            return result;

        }

    }
}
