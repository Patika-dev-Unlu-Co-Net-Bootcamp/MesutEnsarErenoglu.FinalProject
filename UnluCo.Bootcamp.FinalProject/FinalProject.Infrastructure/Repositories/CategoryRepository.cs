using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {

        }
       
        public List<Product> GetProductsbyCategoryId(int id)
        {
            try
            {
                var result = _context.Categories.Any(x => x.Id == id);
                if (result)
                {
                    var subCategories = _context.SubCategories.Where(x => x.CategoryId == id).ToList();

                    if (subCategories != null)
                    {
                        List<Product> products = new List<Product>();

                        foreach (var item in subCategories)
                        {
                            products.AddRange(item.Products);
                        }
                        return products;
                    }

                }
                throw new InvalidOperationException("Böyle bir kategori bulunamadı!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
