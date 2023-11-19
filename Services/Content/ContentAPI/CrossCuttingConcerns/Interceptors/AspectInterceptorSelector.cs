
using Castle.DynamicProxy;
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
            // classAttributes.Add(new LogAspect(typeof(SeqLogger)));
            // classAttributes.Add(new ExceptionLogAspect(typeof(SeqLogger)));
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}