using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using GithubApi.Data;

namespace GithubApi.Service.Middleware
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
                ErrorResponse(ex, httpContext);
            }   
        }     
        
        async void ErrorResponse(Exception ex, HttpContext httpContext)
        {
            string message;
            int statusCode;
            _logger.Information($"Error occured at: {ex.Message}, type: {ex}");

            switch (ex)
            {
                case HttpRequestException:                    
                    message = "Couldn't find user";
                    //It's possible to change message by adding a function that will change it acording to statusCode
                    statusCode = (int)((HttpRequestException)ex).StatusCode;                    
                    break;

                case NotFoundException:
                    message = "Couldn't find user";
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                default:
                    message = "Internal Server Error";
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(message);
        }              
     
    }
}
