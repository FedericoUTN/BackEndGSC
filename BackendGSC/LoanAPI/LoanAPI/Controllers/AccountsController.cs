
using Microsoft.AspNetCore.Mvc;
using LoanAPI.Handlers;
using LoanAPI.Dto;
using System.Security.Cryptography;
using LoanAPI.Entities;
using System.Text;

namespace LoanAPI.Controllers
{

    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IJwtHandler jwtHandler;

        public static User _user = new User();

        public AccountsController(IJwtHandler jwtHandler)
        {
            this.jwtHandler = jwtHandler;
        }

        [HttpPost("Register")]
        public ActionResult<User> Register([FromBody] UserDto user)
        {
            CreatePasswordHash(user.Password!, out byte[] passHash, out byte[] passSalt);
            _user.UserName = user.UserName;
            _user.PasswordHash = passHash;
            _user.PasswordSalt = passSalt;
            return Ok(_user);
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto user) //Es raro que esto sea un POST no?
        {

           //aca :user es uno, deberia  traer varios para comprarar
            if(_user.UserName != user.UserName)
            {
                return BadRequest("Usuario no encontrado");
            }

            if(!VerifyPasswordHash(user.Password!, _user.PasswordHash!, _user.PasswordSalt!))
            {
                return BadRequest("Password incorrecto");
            }
            //Aca deberiamos buscar en nuestra base de datos si existe un usuario con ese username y password
            // para simplificar, si el usuario es 'admin' va a tener el rol admin, si el usuario es 'user' va a tener el rol user.
            var roles = (user.UserName!.ToLower() == "admin") ?
                    new List<string> { "Admin" } :
                    new List<string> { "User" };


            var bearer = jwtHandler.GenerateToken(user, roles);
            return Ok(new
            {
                token = bearer
                ,username = user.UserName
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
