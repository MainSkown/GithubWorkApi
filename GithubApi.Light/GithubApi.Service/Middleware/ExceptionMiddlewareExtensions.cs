using Microsoft.AspNetCore.Builder;

namespace GithubApi.Service.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomMiddleware<T>(this IApplicationBuilder app)
        {
            app.UseMiddleware<T>();
        }
    }
}
