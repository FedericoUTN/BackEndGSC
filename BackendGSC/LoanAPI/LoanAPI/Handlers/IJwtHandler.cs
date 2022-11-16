
using LoanAPI.Dto;

namespace LoanAPI.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(UserDto user, IEnumerable<string> roles);
    }
}