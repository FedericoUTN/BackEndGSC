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
 
    }
}
