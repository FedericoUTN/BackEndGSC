using LoadApi.DataAccess;
using LoadApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.DataAccess
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(LoanContext context)
            : base(context)
        {
        }

        public override Task<Loan?> GetByIdAsync(int id)
        {
            var result = dbSet
                .SingleOrDefaultAsync(l => l.Id == id);
            return result;
        }
        public override Task<List<Loan>> GetAllAsync()
        {
            var result = dbSet
                .Include(l => l.Thing)
                .ToListAsync();
            return result;
        }

        public Task<List<Loan>> GetAllByPersoAsync(int id)
        {
            return dbSet
                .Where(l => l.PersonId == id)
                .ToListAsync();
        }
    }
}
