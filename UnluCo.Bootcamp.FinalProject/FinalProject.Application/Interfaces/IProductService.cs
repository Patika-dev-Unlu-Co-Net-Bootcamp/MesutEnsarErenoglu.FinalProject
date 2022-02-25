using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface IProductService
    {
        Task Add(ProductDto entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        Task Update(ProductDto entity);
        Task<List<ProductDto>> GetAll();
        Task<List<ProductDto>> GetAllInActive();
        Task<List<ProductDto>> GetAllActive();
        Task<ProductDto> GetbyId(int Id);
        Task<List<ProductDto>> GetbyFilter(Expression<Func<ProductDto, bool>> filter);
        Task<bool> Any(int id);
        Task UpdateProductImage(ProductDto entity);
    }
}
