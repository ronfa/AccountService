using Moq;
using Xunit;
using System;
using AccountService.Controllers;
using Banking.Business.Model;
using Banking.Services.Accounting;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using Banking.Persistence.Repositories.Interfaces;
using System.Collections.Generic;

namespace Banking.UnitTesting.Customers
{
    public class CustomerControllerTests : TestBase
    {
        [Fact]
        public async void GetCustomerById()
        {
            var repo = new Mock<ICustomerRespository>();
            repo.Setup(c => c.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Customer { Id = 1, Name = "Bob", Surname = "Roberts", Accounts = new List<Account>() }));

            var service = new CustomerService(_unitOfWork, AutomapperSingleton.Mapper, repo.Object);
            var controller = new CustomerController(NullLogger<CustomerController>.Instance, service);

            var customer = await controller.GetAsync(1);

            Assert.NotNull(customer);
            Assert.Equal("Bob", customer.Name);

        }
    }
}
