using Banking.Services.Resources;
using System.Threading.Tasks;

namespace Banking.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountResource> GetAsync(int accountId);
        Task<AddAccountResponse> SaveAsync(AddAccountResource resource);
    }
}