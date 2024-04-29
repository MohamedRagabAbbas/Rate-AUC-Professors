﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RateAucProfessors.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RateAucProfessors.Authentication
{
    public class Token
    {
        private readonly Jwt _jwt;
        public Token(IOptionsMonitor<Jwt> jwt)
        {
            _jwt = jwt.CurrentValue;
        }
        public string GenerateToken(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        issuer: _jwt.Issuer,
                        audience: _jwt.Audience,
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(_jwt.ExpireAfterInMinutes),
                        signingCredentials: signingCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
