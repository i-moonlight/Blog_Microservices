using Microsoft.Extensions.DependencyInjection;

namespace ContentAPI.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
