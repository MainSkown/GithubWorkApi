using GithubApi.Logger;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GithubApi.Middleware
{
    public class ExceptionCatchMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionCatchMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LoggError($"Error occurred at: {ex.Message}");

                if (ex.Message.Contains("404"))
                {
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsync("Couldn't Find User");
                }
                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await httpContext.Response.WriteAsync("Internal Server Error");
                }
            }   
        }       
    }
}
