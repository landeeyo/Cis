using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace Landeeyo.Cis.Interceptors.Attributes
{
    /// <summary>
    /// Attribute for ExecutionTime interceptor
    /// </summary>
    public class ExecutionTimeAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Context.Kernel.Get<ExecutionTimeInterceptor>();
        }
    }
}
