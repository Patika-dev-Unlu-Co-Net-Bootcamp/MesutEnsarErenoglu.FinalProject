
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Repositories
{
    public class ProductRepository:BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {

        }

        public async Task<List<Product>> GetAllOfferdable()
        {
            var products = await _context.Products.Where(x => x.IsActive == true && x.IsOfferdable == true).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetbyUserId(string id)
        {
            var products = await _context.Products.Where(x => x.AppUserId == id).ToListAsync();
            return products;
        }

        public async Task<bool> IsOfferdable(int id)
        {
            var product = await _context.Products.Where(x => x.Id == id && x.IsOfferdable == true).FirstOrDefaultAsync();
            if (product != null)
            {
                return true;
            }
            return false;
        }
    }
}
