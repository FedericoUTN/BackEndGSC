using LoadApi.DataAccess;
using LoadApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.DataAccess
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(LoanContext context)
            : base(context)
        {
        }
        public override Task<List<Person>> GetAllAsync()
        {
            return dbSet
                .Include(p => p.Address)
                .Where(p => p.Address != null)
                .ToListAsync();
        }
        public override Task<Person?> GetByIdAsync(int id)
        {
            
            var result = dbSet
                .Include(p => p.Address)
                .Where(p => p.Address != null)
                .SingleOrDefaultAsync(p => p.Id == id);
                return result;
           
        }

    }
}
