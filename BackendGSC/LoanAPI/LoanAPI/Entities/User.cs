using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LoadApi.Entities;

namespace LoanAPI.Entities
{
    public class User : EntityBase
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Rol { get; set; }



    }
}
