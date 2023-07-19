﻿using Backend.Models;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services.ServiceImplementations
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly UserManager<User> _userManager;

        public TokenGeneratorService(IConfiguration config, UserManager<User> userManager)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager; 
        }


        public async Task<string> GenerateTokenAsync(User user)
        {
            var claims = new List<Claim>()
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserName)

            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var creds = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = "http://www.security.org",
                Audience = "http://www.security.org",
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
