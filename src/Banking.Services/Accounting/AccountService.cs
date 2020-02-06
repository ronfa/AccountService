using AutoMapper;
using Banking.Business.Model;
using Banking.Persistence.Repositories.Interfaces;
using Banking.Services.Interfaces;
using Banking.Services.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Services.Accounting
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountRespository = accountRepository;
        }

        public async Task<AccountResource> GetAsync(int accountId)
        {
            var account = await _accountRespository.GetAsync(accountId);
            return _mapper.Map<Account, AccountResource>(account);
        }

        public async Task<AddAccountResponse> SaveAsync(AddAccountResource resource)
        {
            var account = _mapper.Map<AddAccountResource, Account>(resource);

            try
            {

                if (resource.InitialCredit.HasValue && resource.InitialCredit.GetValueOrDefault() > 0)
                {
                    account.Transactions = new List<Transaction>();
                    // Initial credit provided, creating a transaction
                    account.Transactions.Add(
                        new Transaction { 
                            Amount = resource.InitialCredit.GetValueOrDefault(),
                            Description = "Initial credit topup",
                            Timestamp = DateTime.UtcNow
                    });
                }
                await _accountRespository.AddAsync(account);

                await _unitOfWork.CompleteAsync();

                return new AddAccountResponse(_mapper.Map<Account, AccountResource>(account));
            }
            catch (Exception ex)
            {
                return new AddAccountResponse($"An error occurred when saving the account: {ex.Message}");
            }
        }
    }
}
