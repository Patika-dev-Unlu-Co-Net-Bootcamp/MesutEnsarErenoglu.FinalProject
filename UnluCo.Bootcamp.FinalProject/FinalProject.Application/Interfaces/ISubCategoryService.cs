

using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface ISubCategoryService
    {
        Task Add(SubCategoryDto entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        Task Update(SubCategoryDto entity);
        Task<List<SubCategoryDto>> GetAll();
        Task<List<SubCategoryDto>> GetAllInActive();
        Task<List<SubCategoryDto>> GetAllActive();
        Task<SubCategoryDto> GetbyId(int Id);
        Task<List<SubCategoryDto>> GetbyFilter(Expression<Func<SubCategoryDto, bool>> filter);
        Task<bool> Any(int id);
        List<ProductDto> GetProductsbySubCategoryId(int id);
    }
}
