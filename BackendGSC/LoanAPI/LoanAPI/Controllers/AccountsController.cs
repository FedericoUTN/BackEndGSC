
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Handlers;
using LoanAPI.Dto;
using System.Security.Cryptography;
using LoanAPI.Entities;
using System.Text;
using LoanAPI.DataAccess;

namespace LoanAPI.Controllers
{

    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IJwtHandler jwtHandler;
        private readonly IUnityOfWork ouw;
        public AccountsController(
            IJwtHandler jwtHandler
            ,IUnityOfWork ouw)
        {
            this.jwtHandler = jwtHandler;
            this.ouw = ouw;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto user)
        {
            var copyUser = await ouw.UserRepository.GetByUsernamePassword(user);
            if (copyUser is null)
            {
                var newUser = new User();
                CreatePasswordHash(user.Password!, out byte[] passHash, out byte[] passSalt);
                newUser.UserName = user.UserName;
                newUser.PasswordHash = passHash;
                newUser.PasswordSalt = passSalt;
                newUser.Rol = "Admin";
                ouw.UserRepository.Add(newUser);
                await ouw.CompleteAsync();
                return Ok(newUser);
            }
                return BadRequest("Ya existe un usuario registrado con ese Username");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto user) 
        {
            var copyUser = await ouw.UserRepository.GetByUsernamePassword(user);
            if (copyUser is null)
            {
                return BadRequest("Usuario no encontrado");
            }

            if(!VerifyPasswordHash(user.Password!, copyUser.PasswordHash!, copyUser.PasswordSalt!))
            {
                return BadRequest("Password incorrecto");
            }
            
            var roles = (copyUser.Rol!.ToLower() == "admin") ?
                    new List<string> { "Admin" } :
                    new List<string> { "User" };

            var bearer = jwtHandler.GenerateToken(copyUser, roles);
            return Ok(new
            {
                token = bearer
                ,username = copyUser.UserName
            });
        }

        private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            
        }
        private bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt)
        {
            using (var hmac = new HMACSHA256(passSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passHash);
            }
        }
    }
}
