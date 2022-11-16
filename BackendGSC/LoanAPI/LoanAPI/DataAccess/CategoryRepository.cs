using LoadApi.DataAccess;
using LoadApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.DataAccess
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LoanContext context)
            : base(context)
        { 
        }

    }
}
