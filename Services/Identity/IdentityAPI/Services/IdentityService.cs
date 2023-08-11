using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace IdentityAPI.Services;

public class IdentityService : IIdentityService
{
    private readonly IConfiguration _configuration;
    public IdentityService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
    {
        var key = Encoding.ASCII.GetBytes("thisiskey92_thisiskey92_thisiskey92_thisiskey92ythisiskey92_thisiskey92_thisiskey92_thisiskey92y");
        var claims = new Claim[]
        {
                new Claim(ClaimTypes.NameIdentifier,loginRequestModel.UserName),
                new Claim(ClaimTypes.Name,"Hamit")
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenhandler = new JwtSecurityTokenHandler();
        var token = tokenhandler.CreateToken(tokenDescriptor);


        LoginResponseModel response = new()
        {
            Token = tokenhandler.WriteToken(token),
            UserName = loginRequestModel.UserName
        };

        return Task.FromResult(response);
    }
}
