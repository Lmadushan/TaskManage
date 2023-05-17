using TaskManage.Common.Middleware;
using Microsoft.AspNetCore.Builder;

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
