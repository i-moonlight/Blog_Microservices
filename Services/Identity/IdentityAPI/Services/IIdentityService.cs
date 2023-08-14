using IdentityAPI.Models.Dtos;
using IdentityAPI.Models.Settings;
using SharedLib.Dtos;

namespace IdentityAPI.Services;

public interface IIdentityService
{
    Task<Response<LoginResponseDto>> Login(LoginRequestDto loginRequestDto);
    Task<Response<RegisterResponseDto>> Register(RegisterRequestDto registerRequestDto);
    string GenerateToken(string userName);
}
