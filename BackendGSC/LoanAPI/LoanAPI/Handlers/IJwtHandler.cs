
using LoanAPI.Dto;
using LoanAPI.Entities;

namespace LoanAPI.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}