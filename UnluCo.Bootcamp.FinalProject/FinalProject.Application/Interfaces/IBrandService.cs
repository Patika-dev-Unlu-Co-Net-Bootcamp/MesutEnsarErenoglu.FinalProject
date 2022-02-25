

using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface IBrandService
    {
        Task Add(BrandDto entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        Task Update(BrandDto entity);
        Task<List<BrandDto>> GetAll();
        Task<List<BrandDto>> GetAllInActive();
        Task<List<BrandDto>> GetAllActive();
        Task<BrandDto> GetbyId(int Id);
        Task<List<BrandDto>> GetbyFilter(Expression<Func<BrandDto, bool>> filter);
        Task<bool> Any(int id);
    }
}
