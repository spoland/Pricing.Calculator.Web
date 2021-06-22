using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pricing.Calculator.Web.App.Forward;
using Pricing.Calculator.Web.App.Services;
using System;
using Syncfusion.Blazor;

namespace Pricing.Calculator.Web.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 65536;
            });

            services.AddHttpClient<IForwardCalculationService, ForwardCalculationService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["CalculatorApi:BaseAddress"]);
            });

            services.AddHttpClient<IReverseCalculationService, ReverseCalculationService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["CalculatorApi:BaseAddress"]);
            });

            services.AddHttpClient<IAdaptivePricingService, AdaptivePricingService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["CalculatorApi:BaseAddress"]);
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
