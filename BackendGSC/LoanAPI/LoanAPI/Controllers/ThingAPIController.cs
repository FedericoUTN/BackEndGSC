using LoadApi.Entities;
using LoanAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingAPIController : ControllerBase
    {
        private readonly IUnityOfWork uow;
        private readonly ILogger<ThingAPIController> logger;

        public ThingAPIController(IUnityOfWork uow, ILogger<ThingAPIController> logger)
        {
            this.uow = uow;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<List<Thing>> GetAll()
        {
            return await uow.ThingRepository.GetAllAsync();
        }
    }
}
