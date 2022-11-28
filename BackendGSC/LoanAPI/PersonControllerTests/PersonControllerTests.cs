using Castle.Core.Logging;
using LoadApi.Entities;
using LoanAPI.Controllers;
using LoanAPI.DataAccess;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using LoadApi.DataAccess;
using Microsoft.AspNetCore.Http;

namespace PersonControllerTests
{
    public class PersonControllerTests
    {
        private PersonController target;
        private Mock<IUnityOfWork> mockUnityOfWork;
        private Mock<ILogger<PersonController>> mockLogger;
        public Person person;
        public PersonControllerTests()
        {
            mockUnityOfWork = new Mock<IUnityOfWork>();
            mockLogger = new Mock<ILogger<PersonController>>();
            person = new Person
            {
                Id = 1,
                FirstName = "Fede",
                LastName = "Vallejo",
                Email = "federicoingsis@gmail.com",
                Address = new Address
                {
                    Id = 1,
                    City = "Rosario",
                    Number = "439",
                    Street = "San Juan"
                }
            };
            mockUnityOfWork.Setup(x => x.PersonRepository.Add(It.IsAny<Person>())).Returns(new Person());
            mockUnityOfWork.Setup(x => x.PersonRepository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Person());
            mockUnityOfWork.Setup(x => x.AddressRepository.Add(It.IsAny<Address>())).Returns(new Address());
            mockUnityOfWork.Setup(x => x.AddressRepository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Address());
            mockUnityOfWork.Setup(x => x.PersonRepository.GetAllAsync()).Returns(Task.FromResult(new List<Person>()));
            mockUnityOfWork.Setup(x => x.PersonRepository.DeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(true));
            mockUnityOfWork.Setup(x => x.AddressRepository.DeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(true));
            mockUnityOfWork.Setup(x => x.PersonRepository.Update(It.IsAny<Person>())).Returns(new Person());
            mockUnityOfWork.Setup(x => x.AddressRepository.Update(It.IsAny<Address>())).Returns(new Address());

            target = new PersonController(
                mockUnityOfWork.Object,
                mockLogger.Object
                );
        }

        [Fact]
        public void Add_Retorna_Code409()
        {
            var result = target.Add(person);

            result.Should().BeOfType<Task<ActionResult<Person>>>();
        }

        [Fact]
        public void GetAll_RetonaAsync_Lista_de_Person()
        {
            var result = target.GetAllAsync();

            result.Should().BeOfType<Task<List<Person>>>();
        }

        [Fact]
        public void GetByIdAsync_RetonaAsync_Person()
        {
            var id = 1;
            
            var result = target.GetByIdAsync(id);

            result.Should().BeOfType<Task<ActionResult<Person>>>();
        }

        [Fact]
        public void DeleteAsync_return_NoContent()
        {
            var id = 1;

            var result = target.DeleteAsync(id);

            result.Should().BeOfType<Task<ActionResult>>();
        }

        [Fact]
        public void Update_return_TaskActionResult()
        {
            var editedPerson = person;
            editedPerson.FirstName = "otro";

            var result = target.Update(editedPerson);

            result.Should().BeOfType<Task<ActionResult>>();
        }

        [Fact]
        public void Add_Retorna_Person()
        {
            mockUnityOfWork.Setup(x => x.PersonRepository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(()=> null);
            var result = target.Add(person);

            result.Should().BeOfType<Task<ActionResult<Person>>>();
        }
        /*[Theory]
        [InlineData()]

        public void Test2()
        {

        }*/
    }
}