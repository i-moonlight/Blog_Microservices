
using Castle.DynamicProxy;
using ContentAPI.CrossCuttingConcerns.Logging;
using ContentAPI.Services;
using System.Reflection;

namespace ContentAPI.CrossCuttingConcerns.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new LogAspect());
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}