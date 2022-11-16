using LoadApi.DataAccess;
using LoadApi.Entities;

namespace LoanAPI.DataAccess
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        public ThingRepository(LoanContext context)
            : base(context)
        {
        }
    }
}
