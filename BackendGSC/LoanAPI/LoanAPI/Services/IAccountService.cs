using System.Security.Cryptography;
using System.Text;

namespace LoanAPI.Services
{
    public interface IAccountService
    {
        void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt);

        bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt);
    }
}
