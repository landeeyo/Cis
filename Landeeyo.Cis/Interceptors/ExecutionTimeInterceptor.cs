using Ninject.Extensions.Interception;
using System;
using System.Diagnostics;

namespace Landeeyo.Cis.Interceptors
{
    /// <summary>
    /// Interceptor used for method execution time measurement.
    /// </summary>
    public class ExecutionTimeInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Method started");

            var watch = Stopwatch.StartNew();

            invocation.Proceed();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Method execution time: {1} ms", invocation.GetType(), elapsedMs);
        }
    }
}
