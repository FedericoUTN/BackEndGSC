using LoadApi.Entities;
using LoanAPI.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IUnityOfWork uow;
        private readonly ILogger<PersonController> logger;

        public PersonController(IUnityOfWork uow, ILogger<PersonController> logger)
        {
            this.uow = uow;
            this.logger = logger;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Person>> Add([FromBody] Person person)
        {
            var copyPerson = await uow.PersonRepository.GetByIdAsync(person.Id);
            if (copyPerson is null )
            {
                var newPerson = uow.PersonRepository.Add(person);
                var copyAddress = await uow.AddressRepository.GetByIdAsync(person.AddressId);
                if (copyAddress is null && person.Address is not null)
                {
                    uow.AddressRepository.Add(person.Address);
                }                   
                await uow.CompleteAsync();
                logger.LogInformation("Persona creada.");
                return Created($"Person/{newPerson.Id}", newPerson);
            }
            else return StatusCode(409);

        }
        [HttpGet]
        public async Task<List<Person>> GetAllAsync()
        {
            var people = await uow.PersonRepository.GetAllAsync();
            return people;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Person>> GetByIdAsync(int id)
        {
            var person = await uow.PersonRepository.GetByIdAsync(id);
            if(person is not null)
                return person;
            else
                return NotFound();

        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var tempAddressPerson = await uow.PersonRepository.GetByIdAsync(id);
            if (tempAddressPerson is not null)
            {
                var tempAddressId = tempAddressPerson.AddressId;
                var isDeletedAddress = await uow.AddressRepository.DeleteAsync(tempAddressId);
                var isDeletedPerson = await uow.PersonRepository.DeleteAsync(id);
                if (isDeletedPerson && isDeletedAddress)
                {
                    await uow.CompleteAsync();
                    logger.LogInformation("Persona y Direccion borradas");
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update([FromBody] Person person)
        {
            var updatePerson = uow.PersonRepository.Update(person);
            if(updatePerson.Address is not null)
                uow.AddressRepository.Update(updatePerson.Address);
            await uow.CompleteAsync();
            logger.LogInformation($"{updatePerson.FirstName} fue Actualizado");
            return Ok();
        }
    }
}
