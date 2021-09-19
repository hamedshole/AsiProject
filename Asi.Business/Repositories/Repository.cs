using Asi.Domain.Common;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IAsiDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(IAsiDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            entity.Delete();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity = await _dbSet.Where(expression).SingleOrDefaultAsync();
            return entity;
        }

        public virtual async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression)
        {
            //var x = _dbSet.Where(expression).FirstOrDefault();
            List<TEntity> entities = await _dbSet.Where(expression).ToListAsync();
            return entities;
        }

        public virtual PagedList<TEntity> PagedList(PaginationFilter pagination, Expression<Func<TEntity, bool>> expression)
        {
            PagedList<TEntity> entities = _dbSet.Where(expression).ToPagedList(pagination);
            return entities;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
