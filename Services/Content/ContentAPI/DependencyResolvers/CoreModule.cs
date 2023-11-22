
using ContentAPI.IoC;
using ContentAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace ContentAPI.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILogService,LogService>();
        }
    }
}
