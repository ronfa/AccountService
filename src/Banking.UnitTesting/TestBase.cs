using Moq;
using System;
using Banking.Persistence.Contexts;
using Banking.Persistence.Repositories;
using Banking.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banking.UnitTesting
{
    public abstract class TestBase : IDisposable
    {
        protected AppDbContext _mockContext;
        protected IUnitOfWork _unitOfWork;

        protected TestBase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "banking-api-in-memory")
                .Options;

            _mockContext = new AppDbContext(options);
            _unitOfWork = new UnitOfWork(_mockContext);
        }

        public void Dispose()
        {
            
        }
    }
}
