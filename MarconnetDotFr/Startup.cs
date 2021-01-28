using LastFM.AspNetCore.Stats.Utils;
using MarconnetDotFr.Core.Services;
using MarconnetDotFr.DataAccess.Repositories;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarconnetDotFr
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
            services.AddRazorPages();
            services.AddKendo();

            services.AddScoped<IResumeRepository, XMLFilesResumeRepository>();
            services.AddScoped<IWorkRepository, XmlFilesWorkRepository>();
            services.AddScoped<IFootyRepository, XmlFilesFootyRepository>();

            // LastFM
            string lastFMAPIKey = Configuration["LastFMCredentials:APIKey"];
            string lastFMSharedSecret = Configuration["LastFMCredentials:SharedSecret"];
            LastFMCredentials credentials = new LastFMCredentials()
            {
                APIKey = lastFMAPIKey,
                SharedSecret = lastFMSharedSecret
            };
            services.AddScoped<ILastFMStatsService>(_ => new LastFMStatsService(credentials));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}