using LoadApi.DataAccess;
using LoadApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.DataAccess
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        protected LoanContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(LoanContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            var savedEntity = dbSet.Add(entity);
            return savedEntity.Entity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
                return false;
            dbSet.Remove(entity);
                return true;
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            if (id == 0)
                return null;
               
            var savedEntity = await dbSet.SingleOrDefaultAsync(x => x.Id == id);
            return savedEntity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var changedEntity = dbSet.Update(entity);
            return changedEntity.Entity;
        }
    }
}
