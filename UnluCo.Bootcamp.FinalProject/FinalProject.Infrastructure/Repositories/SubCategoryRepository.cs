using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Infrastructure.Repositories
{
    public class SubCategoryRepository:BaseRepository<SubCategory>,ISubCategoryRepository
    {
        public SubCategoryRepository(AppDbContext context):base(context)
        {

        }
        public List<Product> GetProductsbySubCategoryId(int id)
        {
            try
            {
                var result = _context.SubCategories.Any(x => x.Id == id);
                if (result)
                {
                    var products = _context.Products.Where(x => x.SubCategoryId == id).ToList();
                    return products;
                }
                throw new InvalidOperationException("Böyle bir alt kategori bulunamadı!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
