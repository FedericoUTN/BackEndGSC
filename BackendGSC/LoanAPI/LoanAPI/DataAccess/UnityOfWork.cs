using LoadApi.DataAccess;

namespace LoanAPI.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly LoanContext context;
        public IPersonRepository PersonRepository { get; private set; }
        public IThingRepository ThingRepository { get; private set; }
        public ILoanRepository LoanRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IAddressRepository AddressRepository { get; private set; }
        public UnityOfWork(LoanContext context)
        {
            this.context = context;
            PersonRepository = new PersonRepository(context);
            ThingRepository = new ThingRepository(context);
            LoanRepository = new LoanRepository(context);
            CategoryRepository = new CategoryRepository(context);
            AddressRepository = new AddressRepository(context);
        }
        public Task<int> CompleteAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
