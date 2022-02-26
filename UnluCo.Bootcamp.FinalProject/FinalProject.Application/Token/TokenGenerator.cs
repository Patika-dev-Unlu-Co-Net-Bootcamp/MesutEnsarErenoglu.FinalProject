using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProject.Application.Token
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token CreateToken(string Id)
        {
            Token token = new Token();
            DateTime expiration = DateTime.Now.AddHours(1);
            token.TokenExpiration = expiration;

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new JwtSecurityToken
                (
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: new Claim[]
                {
                   new Claim(ClaimTypes.NameIdentifier,Id),
                });
            
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = Guid.NewGuid();

            return token;
        }
    }
}
