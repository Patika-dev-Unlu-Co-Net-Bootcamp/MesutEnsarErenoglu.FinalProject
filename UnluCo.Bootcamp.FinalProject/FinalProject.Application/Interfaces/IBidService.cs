

using FinalProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces
{
    public interface IBidService
    {
        Task Add(BidDto entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        Task Update(BidDto entity);
        Task<List<BidDto>> GetAll();
        Task<List<BidDto>> GetAllInActive();
        Task<List<BidDto>> GetAllActive();
        Task<BidDto> GetbyId(int Id);
        Task<List<BidDto>> GetbyFilter(Expression<Func<BidDto, bool>> filter);
        Task<bool> Any(int id);
    }
}
