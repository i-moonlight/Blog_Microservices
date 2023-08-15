using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using IdentityAPI.Models;
using IdentityAPI.Models.Dtos;
using IdentityAPI.Models.Settings;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SharedLib.Dtos;

namespace IdentityAPI.Services;

public class IdentityService : IIdentityService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoCollection<User> _userCollection;
    public IdentityService(IConfiguration configuration, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _userCollection = database.GetCollection<User>(databaseSettings.UserCollectionName);
        _configuration = configuration;
    }

    public string GenerateToken(string userName)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["TokenOptions:SecurityKey"]);
        var claims = new Claim[]
        {
                new Claim(ClaimTypes.Name,userName)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenhandler = new JwtSecurityTokenHandler();
        var token = tokenhandler.CreateToken(tokenDescriptor);

        return tokenhandler.WriteToken(token);
    }
    public async Task<Response<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
    {
        var chkUser = await _userCollection.FindAsync<User>(u =>
        u.UserName == loginRequestDto.UserName &&
        u.Password == loginRequestDto.Password);

        if (!chkUser.Any())
            return Response<LoginResponseDto>.Fail("User not found", (int)HttpStatusCode.Unauthorized);
        

        LoginResponseDto response = new()
        {
            Token = GenerateToken(loginRequestDto.UserName),
            UserName = loginRequestDto.UserName
        };

        return Response<LoginResponseDto>.Success(response, 200);
    }
    public async Task<Response<RegisterResponseDto>> Register(RegisterRequestDto registerRequestDto)
    {
        var chkUser = await _userCollection.FindAsync<User>(u => u.Email == registerRequestDto.Email);

        User newUser = new();
        if (!chkUser.Any())
        {
            newUser.UserName = registerRequestDto.UserName;
            newUser.CreatedTime = DateTime.Now;
            newUser.Email = registerRequestDto.Email;
            newUser.Password = registerRequestDto.Password;
            await _userCollection.InsertOneAsync(newUser);
        }else
            return Response<RegisterResponseDto>.Fail("username or email already using",(int)HttpStatusCode.Unauthorized);

        RegisterResponseDto response = new()
        {
            user = newUser
        };

        return Response<RegisterResponseDto>.Success(response, 200);
    }
}
