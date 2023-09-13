using MyBlogAPI.Models;
using MyBlogAPI.Services;
using MyBlogAPI.Services.Interfaces;

namespace MyBlogAPI.Extensions;

public static class ServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
    {
        var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        services.AddHttpClient<IContentService, ContentService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Content.Path}");
        });

    }
}
