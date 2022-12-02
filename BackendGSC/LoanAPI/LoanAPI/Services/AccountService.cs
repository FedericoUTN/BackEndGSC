using System.Security.Cryptography;
using System.Text;

namespace LoanAPI.Services
{
    public class AccountService : IAccountService
    {
        public void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }
        public bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt)
        {
            using (var hmac = new HMACSHA256(passSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passHash);
            }
        }
    }
}
