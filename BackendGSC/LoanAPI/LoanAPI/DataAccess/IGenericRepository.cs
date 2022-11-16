using LoadApi.Entities;

namespace LoadApi.DataAccess
{
    public interface IGenericRepository<TEntity>
       where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);

        Task<bool> DeleteAsync(int id);

        TEntity Update(TEntity entity);

        Task<TEntity?> GetByIdAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        
    }
}
