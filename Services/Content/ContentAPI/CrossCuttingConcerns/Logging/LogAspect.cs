using Castle.DynamicProxy;
using ContentAPI.CrossCuttingConcerns.Interceptors;
using ContentAPI.IoC;
using ContentAPI.Services;
using System;


namespace ContentAPI.CrossCuttingConcerns.Logging
{
   public class LogAspect : MethodInterception
   {
      protected override void OnBefore(IInvocation invocation)
      {
         var _logService = ServiceTool.ServiceProvider.GetService<ILogService>();
         if (invocation.Arguments.Length > 0)
         {
            _logService.Publish(new Models.Dtos.LogCreatedEvent()
            {
               Message = invocation.Method.Name + " metodu parametresi =" + invocation.Arguments[0],
               LogType = "info",
               CreatedDate = new DateTime()
            });
         }
      }
   }
}




