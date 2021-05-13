using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApi.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomMiddleware<T>(this IApplicationBuilder app)
        {
            app.UseMiddleware<T>();
        }
    }
}
