using AutoMapper;
using LoadApi.Entities;
using LoanAPI.DataAccess;
using LoanAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : Controller
    {
            private readonly IUnityOfWork uow;
            private readonly ILogger<PersonController> logger;
            private readonly IMapper mapper;
            public LoanController(
                IUnityOfWork uow
                , ILogger<PersonController> logger
                , IMapper mapper)
            {
                this.uow = uow;
                this.logger = logger;
                this.mapper = mapper;
            }

        [HttpPost]
        public async Task<ActionResult<Loan>> AddLoan([FromBody] LoanDto loan)
        {
            var copyLoan = await uow.LoanRepository.GetByIdAsync(loan.id);
            if (copyLoan is null)
            {
                var mappedLoan = mapper.Map<Loan>(loan);
                var newLoan = uow.LoanRepository.Add(mappedLoan);
                await uow.CompleteAsync();
                logger.LogInformation("Loan creado");
                return Ok(newLoan);
            }
            else return BadRequest($"Ya existe {copyLoan}");
        }
        [HttpGet]
        public async Task<List<Loan>> GetAllByPerson(int id)
        {
            var loans = await uow.LoanRepository.GetAllByPersoAsync(id);
            return loans;
        }
    }
}
