
using FinalProject.Domain.Entities;
using System.Collections.Generic;

namespace FinalProject.Domain.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        List<Product> GetProductsbyCategoryId(int id);
    }
}
