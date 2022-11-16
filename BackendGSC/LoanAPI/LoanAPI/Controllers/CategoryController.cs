
using LoadApi.Entities;
using LoanAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CategoryController : ControllerBase
    {
        private readonly IUnityOfWork ouw;

        public CategoryController(IUnityOfWork ouw)
        {
            this.ouw = ouw;
        }

        [HttpPost]
        [Route("Categories")]
        public async Task<ActionResult<Category>> Add([FromBody] Category category)
        {
            var copyCategory = await ouw.CategoryRepository.GetByIdAsync (category.Id);
            if (copyCategory is not null)
            {
                var newCategory = ouw.CategoryRepository.Add(category);
                await ouw.CompleteAsync();
                return newCategory;
            }
            else return StatusCode(409);

        }
    

    }
}
