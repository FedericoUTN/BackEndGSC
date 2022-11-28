using LoadApi.DataAccess;
using LoanAPI.Dto;
using LoanAPI.Entities;

namespace LoanAPI.DataAccess
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernamePassword(UserDto user);
    }
    
}
