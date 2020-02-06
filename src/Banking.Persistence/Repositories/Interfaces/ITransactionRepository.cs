using Banking.Business.Model;
using System.Threading.Tasks;

namespace Banking.Persistence.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<Transaction> GetAsync(int Id);
    }
}