using FinalProject.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task Delete(int id);
        Task RemoveFromDb(int id);
        void Update(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllInActive();
        Task<List<TEntity>> GetAllActive();
        Task<TEntity> GetbyId(int Id);
        Task<List<TEntity>> GetbyFilter(Expression<Func<TEntity, bool>> filter);
        Task<bool> Any(Expression<Func<TEntity, bool>> filter);
    }
}
