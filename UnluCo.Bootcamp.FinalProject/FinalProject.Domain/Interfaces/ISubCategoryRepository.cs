using FinalProject.Domain.Entities;
using System.Collections.Generic;

namespace FinalProject.Domain.Interfaces
{
    public interface ISubCategoryRepository:IRepository<SubCategory>
    {
        List<Product> GetProductsbySubCategoryId(int id);
    }
}
