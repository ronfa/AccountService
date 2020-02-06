using Moq;
using Xunit;
using System;
using AccountService.Controllers;
using Banking.Business.Model;
using Banking.Services.Accounting;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using Banking.Persistence.Repositories.Interfaces;

namespace Banking.UnitTesting.Transactions
{
    public class TransactionControllerTests : TestBase
    {
        [Fact]
        public async void GetTransactionById()
        {
            var repo = new Mock<ITransactionRepository>();
            repo.Setup(c => c.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Transaction { Id = 1, Amount = 1.00, AccountId = 1, Timestamp = DateTime.UtcNow, Description = "Initial Credit" }));

            var service = new TransactionService(_unitOfWork, AutomapperSingleton.Mapper, repo.Object);
            var controller = new TransactionController(NullLogger<TransactionController>.Instance, service);

            var transaction = await controller.GetAsync(1);

            Assert.NotNull(transaction);
            Assert.Equal(1.00, transaction.Amount);

        }
    }
}
