using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityService.Models;
using Microsoft.IdentityModel.Tokens;

namespace IdentityService.Services
{
    public class AuthService : IAuthService
    {
        readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,loginRequestModel.UserName),
                new Claim(ClaimTypes.Name,"admin")
            };
            var now = DateTime.UtcNow;
            var tokenOptions = _configuration.GetSection("TokenOptions");
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenOptions["SecurityKey"]));

            var jwt = new JwtSecurityToken(
                issuer: tokenOptions["Iss"],
                audience: tokenOptions["Aud"],
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(60)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            LoginResponseModel response = new()
            {
                Token = encodedJwt,
                UserName = loginRequestModel.UserName
            };

            return Task.FromResult(response);
        }
    }
}