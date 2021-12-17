using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GithubApi.Repo.Models;
using GithubApi.Repo;
using GithubApi.Service.Middleware;
using GithubApi.Data;
using Serilog;
using System;

namespace GithubApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("UserList"));

            services.Configure<LinkOptions>(Configuration.GetSection("LinkOptions"));

            services.AddSingleton<IGithubRepo, GithubRepo>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IListRepo, ListRepo>();

            Log.Logger = new LoggerConfiguration().WriteTo.File(Configuration.GetSection("LinkOptions:LogPath").Value, rollingInterval: RollingInterval.Day).CreateLogger();

            services.AddSingleton(Log.Logger);

            services.AddHttpClient<IGithubRepo, GithubRepo>(httpClient =>
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

                httpClient.BaseAddress = new Uri(Configuration.GetSection("LinkOptions:GithubUrl").Value);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseMiddleware<ExceptionCatchMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
