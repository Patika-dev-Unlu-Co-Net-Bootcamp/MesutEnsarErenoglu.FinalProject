using Blazored.LocalStorage;
using FinalProject.UI.Authentication;
using FinalProject.UI.Data;
using FinalProject.UI.Services;
using FinalProject.UI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinalProject.UI
{
    // Todo: User ve Bid servisleri tamamlanacak
    // Todo: Product, user ve bid sayfalarý tamamlanacak
    // Todo: Genel tasarým güncellenecek
    
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
            services.AddHttpClient();
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredLocalStorage();
            services.AddAuthenticationCore();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<IAccountClientService, AccountClientService>();
            services.AddScoped<ICategoryClientService, CategoryClientService>();
            services.AddScoped<ISubCategoryClientService, SubCategoryClientService>();
            services.AddScoped<IBrandClientService, BrandClientService>();
            services.AddScoped<IColorClientService, ColorClientService>();
            services.AddScoped<IProductClientService, ProductClientService>();
            
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
