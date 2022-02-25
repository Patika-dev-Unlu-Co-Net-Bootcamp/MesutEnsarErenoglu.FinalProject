using FinalProject.Application.Interfaces;
using FinalProject.Application.Mapping;
using FinalProject.Application.Services;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.Repositories;
using FinalProject.Infrastructure.UnitOfWork;
using FinalProject.Infrastructure.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinalProject.Application.DIContainer
{
    public static class DIContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("defaultConnection"), b => b.MigrationsAssembly("FinalProject.Infrastructure")));
            
            services.AddIdentityCore<AppUser>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredLength = 6;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();


            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
