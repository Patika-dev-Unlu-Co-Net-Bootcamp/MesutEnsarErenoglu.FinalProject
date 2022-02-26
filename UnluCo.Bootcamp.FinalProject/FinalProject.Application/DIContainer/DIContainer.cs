
using FinalProject.Application.Interfaces;
using FinalProject.Application.Mapping;
using FinalProject.Application.Services;
using FinalProject.Application.Token;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.Repositories;
using FinalProject.Infrastructure.UnitOfWork;
using FinalProject.Infrastructure.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace FinalProject.Application.DIContainer
{
    public static class DIContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("defaultConnection"), b => b.MigrationsAssembly("FinalProject.Infrastructure")));
            
            services.AddIdentity<AppUser,IdentityRole>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.SignIn.RequireConfirmedAccount = true;
            })
                //.AddRoles<IdentityRole>()
                //.AddUserManager<UserManager<AppUser>>()
                //.AddRoleManager<RoleManager<IdentityRole>>()
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = true,
                   ValidateIssuer = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration["Token:Issuer"],
                   ValidAudience = configuration["Token:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                   ClockSkew = TimeSpan.Zero
               };
            });


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

            services.AddScoped<IAppUserService, AppUserService>();

            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddScoped<TokenGenerator>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
