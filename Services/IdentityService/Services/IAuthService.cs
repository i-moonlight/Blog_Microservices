using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityService.Models;

namespace IdentityService.Services
{
    public interface IAuthService
    {
        Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel);
    }
}