using LoadApi.DataAccess;
using LoadApi.Entities;

namespace LoanAPI.DataAccess
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(LoanContext context)
            : base(context)
        {
        }

    }
}
