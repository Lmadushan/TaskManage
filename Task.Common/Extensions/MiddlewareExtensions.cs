using Microsoft.AspNetCore.Builder;
using TaskManage.Common.Middleware;

namespace TaskManage.Common.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
