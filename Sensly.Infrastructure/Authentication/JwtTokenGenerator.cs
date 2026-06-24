using Microsoft.IdentityModel.Tokens;
using Sensly.Core.Domain.Entities;
using Sensly.Core.ServiceContracts.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sensly.Infrastructure.Authentication
{
    internal class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateAccessToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),

            };
            
            claims.AddRange(user.UserRoles.Select(ur =>

                 new Claim(ClaimTypes.Role, ur.Role.RoleName)
            ));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("q7F3m9Kp2vX8sL0eR4tY6uH1aZcD9nW5"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "Sensly-Api",
                audience: "Sensly-Web",
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(15)
                );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
