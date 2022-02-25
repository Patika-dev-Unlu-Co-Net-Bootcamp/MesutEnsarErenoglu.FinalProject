using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface ICategoryService
    {
        Task Add(CategoryDto entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        Task Update(CategoryDto entity);
        Task<List<CategoryDto>> GetAll();
        Task<List<CategoryDto>> GetAllInActive();
        Task<List<CategoryDto>> GetAllActive();
        Task<CategoryDto> GetbyId(int Id);
        Task<List<CategoryDto>> GetbyFilter(Expression<Func<CategoryDto, bool>> filter);
        Task<bool> Any(int id);
        List<ProductDto> GetProductsbyCategoryId(int id);
    }
}
