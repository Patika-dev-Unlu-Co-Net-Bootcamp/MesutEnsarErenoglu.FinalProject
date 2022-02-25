

using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface IColorService
    {
        Task Add(ColorDto entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        Task Update(ColorDto entity);
        Task<List<ColorDto>> GetAll();
        Task<List<ColorDto>> GetAllInActive();
        Task<List<ColorDto>> GetAllActive();
        Task<ColorDto> GetbyId(int Id);
        Task<List<ColorDto>> GetbyFilter(Expression<Func<ColorDto, bool>> filter);
        Task<bool> Any(int id);
    }
}
