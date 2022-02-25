using FinalProject.Domain.Entities.Abstract;
using FinalProject.Domain.Interfaces;
using FinalProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> dataSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            dataSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await dataSet.AddAsync(entity);
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> filter)
        {
            return await dataSet.AnyAsync(filter);
        }

        public async Task Delete(int id)
        {
            var entity = await GetbyId(id);
            entity.IsActive = false;
            Update(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dataSet.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllActive()
        {
            
            return await dataSet.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllInActive()
        {
            return await dataSet.Where(x => x.IsActive == false).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetbyFilter(Expression<Func<TEntity, bool>> filter)
        {
            return await dataSet.Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetbyId(int Id)
        {
            var entity = await dataSet.SingleOrDefaultAsync(x => x.Id == Id);
            return entity;
        }
        
        public async Task RemoveFromDb(int id)
        {
            var entity = await GetbyId(id);
            dataSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dataSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
