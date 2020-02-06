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

namespace Banking.UnitTesting.Accounts
{
    public class AccountControllerTests : TestBase
    {
        [Fact]
        public async void GetAccountById()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(c => c.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Account { 
                        Id = 1, 
                        Transactions = new List<Transaction> { 
                            new Transaction { Amount = 101}, 
                            new Transaction { Amount = -10 } 
                        } 
                }));

            var service = new Services.Accounting.AccountService(_unitOfWork, AutomapperSingleton.Mapper, repo.Object);
            var controller = new AccountController(NullLogger<AccountController>.Instance, service);

            var account = await controller.GetAsync(1);

            Assert.NotNull(account);
            Assert.Equal(2, account.Transactions.Count);
            Assert.Equal(91, account.Balance);

        }

    }
}
