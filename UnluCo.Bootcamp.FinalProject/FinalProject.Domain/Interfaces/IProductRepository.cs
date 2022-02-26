
using FinalProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> IsOfferdable(int id);
        Task<List<Product>> GetbyUserId(string id);
        Task<List<Product>> GetAllOfferdable();
    }
}
