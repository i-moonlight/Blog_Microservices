using IdentityAPI.Models;

namespace IdentityAPI.Services;

public interface IIdentityService
{
 Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel);
}
