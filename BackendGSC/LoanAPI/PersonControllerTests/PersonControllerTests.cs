using Castle.Core.Logging;
using LoadApi.Entities;
using LoanAPI.Controllers;
using LoanAPI.DataAccess;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace PersonControllerTests
{
    public class PersonControllerTests
    {
        private PersonController target;
        private Mock<IUnityOfWork> mockUnityOfWork;
        private Mock<ILogger<PersonController>> mockLogger;
        public Person person;
        public Task<Person> taskPerson;
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
            

            mockUnityOfWork.Setup(x => x.PersonRepository.Add(It.IsAny<Person>())).Returns(person);
            mockUnityOfWork.Setup(x => x.PersonRepository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Person { });
           

            target = new PersonController(
                mockUnityOfWork.Object,
                mockLogger.Object
                );
        }

        [Fact]
        public void Add_Retorna_TaskActionResultPerson()
        {
            var result = target.Add(person);

            result.Should().BeOfType<Task<ActionResult<Person>>>();

        }

        [Fact]
        public void Add_Retorna_StatusCode409()
        {
            
        }

        /*[Theory]
        [InlineData()]

        public void Test2()
        {

        }*/
    }
}