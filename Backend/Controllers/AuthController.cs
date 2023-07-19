using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Backend.Logic.Intefaces;
using Backend.Services.ServiceInterfaces;
using System.Net;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogic<User> _userLogic;
        private readonly ITokenGeneratorService _tokenGeneratorService;


        public AuthController(UserManager<User> userManager, ILogic<User> userLogic, ITokenGeneratorService tokenGeneratorService)
        {
            _userManager = userManager;
            _userLogic = userLogic;
            _tokenGeneratorService = tokenGeneratorService;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // get the specific user from the database -> it might be slow in a bigger dataset
            var user = _userLogic.GetAll().SingleOrDefault(t => t.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                string computeHash = Encoding.UTF8.GetString(hash, 0, hash.Length);

                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
                }

                return Ok(new UserDto()
                {
                    Username = user.UserName,
                    Token = await _tokenGeneratorService.GenerateTokenAsync(user)
                });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (UserExists(registerDto.Username)) return BadRequest("Username is already taken!");
            if (UserExists(registerDto.Email)) return BadRequest("Email is already taken!");

            User user = new User();

            using var hmac = new HMACSHA512();

            user.UserName = registerDto.Username;
            user.Email = registerDto.Email;
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PasswordHash = Encoding.UTF8.GetString(hash, 0, hash.Length);
            user.PasswordSalt = hmac.Key;

            _userLogic.Create(user);
            _userLogic.SaveChanges();

            return Ok(new UserDto()
            {
                Username = user.UserName,
                Token = await _tokenGeneratorService.GenerateTokenAsync(user)
            });
        }

        [HttpPost("addadmin")]
        public async Task<IActionResult> AddAdmin([FromBody] string email)
        {
            try
            {
                User? user = _userLogic.GetAll().FirstOrDefault(x => x.Email == email);

                if (user == null)
                {
                    throw new Exception($"User does not exist with id: {email}");
                }

                await _userManager.AddToRoleAsync(user, "Admin");


                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }

        private bool UserExists(string username)
        {
            bool exist = _userLogic.GetAll().Any(x => x.UserName.Equals(username));
            return exist;
        }

        private bool EmailExists(string email)
        {
            bool exist = _userLogic.GetAll().Any(x => x.Email.Equals(email));
            return exist;
        }
    }
}
