using LoadApi.DataAccess;
using LoadApi.Entities;

namespace LoanAPI.DataAccess
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(LoanContext context)
            : base(context)
        {
        }
    }
}
