using GithubApi.Data;
using GithubApi.Repo;
using GithubApi.Repo.Models;
using GithubApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace GithubApi.Web
{
    public static class RegisterService
    {
        public static void RegisterHttpClient(this IServiceCollection services, string url)
        {
            services.AddHttpClient<IGithubRepo, GithubRepo>(httpClient =>
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

                httpClient.BaseAddress = new Uri(url);
            });
        }

        public static void RegisterOptions(this IServiceCollection services, IConfiguration options)
        {
            services.Configure<LinkOptions>(options);
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IGithubRepo, GithubRepo>();
            services.AddScoped<IListRepo, ListRepo>();
            services.AddScoped<IListService, ListService>();
        }

        public static void RegisterLogger(this IServiceCollection services, string logPath)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(logPath, rollingInterval: RollingInterval.Day).CreateLogger();

            services.AddSingleton(Log.Logger);
        }

        public static void RegisterContext(this IServiceCollection services)
        {
            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("UserList"));
        }
    }
}
