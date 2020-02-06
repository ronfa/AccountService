using Banking.Business.Model;
using System.Threading.Tasks;

namespace Banking.Persistence.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(int Id);
        Task AddAsync(Account account);
    }
}