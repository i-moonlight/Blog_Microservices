using Castle.DynamicProxy;
using ContentAPI.Services;
using System;


 namespace ContentAPI.CrossCuttingConcerns.Logging
 {
    // public class LogAspect : InterceptionAttribute
    // {
    //     // private readonly ILogService _logger;
    //     public LogAspect()
    //     {
    //         // _logger = Log.ForContext(GetType());
    //     }

    //     public override void OnBefore(IInvocation invocation)
    //     {
    //         // _logger.Information(invocation.Method.Name + " started.");

    //     }
    //     public override void OnException(IInvocation invocation, Exception e)
    //     {
    //         // _logger.Error("While " + invocation.Method.Name + " works something went wrong.");
    //     }

    //     public override void OnSuccess(IInvocation invocation)
    //     {
    //         // _logger.Information(invocation.Method.Name + " successfully worked");
    //     }
    //     public override void OnAfter(IInvocation invocation)
    //     {
    //         // _logger.Information(invocation.Method.Name + " has finished working.");
    //     }
    // }
 }




