using FinalProject.Domain.Entities.Abstract;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(AppDbContext context, IBidRepository bidRepository, IBrandRepository brandRepository,ICategoryRepository categoryRepository, IColorRepository colorRepository, IProductRepository productRepository, ISubCategoryRepository subCategoryRepository, IHttpContextAccessor HttpContextAccessor)
        {
            _context = context;
            BidRepository = bidRepository;
            BrandRepository = brandRepository;
            CategoryRepository = categoryRepository;
            ColorRepository = colorRepository;
            ProductRepository = productRepository;
            SubCategoryRepository = subCategoryRepository;
            _httpContextAccessor = HttpContextAccessor;
        }

        public IBidRepository BidRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public ICategoryRepository CategoryRepository { get ; }
        public IColorRepository ColorRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            var modifiedEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            string identity = _httpContextAccessor.HttpContext.User.Identity.Name;
            string computer = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            IPAddress ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

            foreach (var item in modifiedEntries)
            {
                var entity = item.Entity as BaseEntity;

                if (entity != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedDate = dateTime;
                        entity.CreatedIP = ip.ToString();
                        entity.CreatedComputerName = computer;
                        entity.CreatedUserName = identity;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.IsModified = true;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedIP = ip.ToString();
                        entity.ModifiedComputerName = computer;
                        entity.ModifiedUserName = identity;
                    }
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}
