
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;

namespace FinalProject.Infrastructure.Repositories
{
    public class ProductRepository:BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {

        }
    }
}
