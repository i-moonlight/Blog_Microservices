using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ContentAPI.CrossCuttingConcerns.Interceptors;
using ContentAPI.Models.Settings;
using ContentAPI.Services;
using Microsoft.Extensions.Options;

namespace AOPSample.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}