using LoadApi.Entities;

namespace LoadApi.DataAccess
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<List<Loan>> GetAllByPersoAsync(int id);
    }
}
