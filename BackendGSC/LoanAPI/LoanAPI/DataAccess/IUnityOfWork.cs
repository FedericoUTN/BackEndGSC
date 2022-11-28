using LoadApi.DataAccess;

namespace LoanAPI.DataAccess
{
    public interface IUnityOfWork
    {
        IThingRepository ThingRepository {get; }
        IPersonRepository PersonRepository {get; }
        ILoanRepository LoanRepository {get; }
        ICategoryRepository CategoryRepository {get; } 
        IAddressRepository AddressRepository {get; }
        IUserRepository UserRepository {get; }
        Task<int> CompleteAsync();
    }
}
