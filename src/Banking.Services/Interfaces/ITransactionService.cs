using Banking.Services.Resources;
using System.Threading.Tasks;

namespace Banking.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionResource> GetAsync(int transactionId);
        Task<AddTransactionResponse> SaveAsync(TransactionResource resource);
    }
}