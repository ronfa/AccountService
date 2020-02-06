using AutoMapper;
using Banking.Business.Model;
using Banking.Persistence.Repositories.Interfaces;
using Banking.Services.Interfaces;
using Banking.Services.Resources;
using System;
using System.Threading.Tasks;

namespace Banking.Services.Accounting
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ITransactionRepository transactionRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionResource> GetAsync(int transactionId)
        {
            var customer = await _transactionRepository.GetAsync(transactionId);

            return _mapper.Map<Transaction, TransactionResource>(customer);
        }

        public async Task<AddTransactionResponse> SaveAsync(TransactionResource resource)
        {
            var transaction = _mapper.Map<TransactionResource, Transaction>(resource);

            try
            {

                await _transactionRepository.AddAsync(transaction);

                await _unitOfWork.CompleteAsync();

                return new AddTransactionResponse(_mapper.Map<Transaction, TransactionResource>(transaction));
            }
            catch (Exception ex)
            {
                return new AddTransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }
    }
}
