using Banking.Business.Model;
using System.Threading.Tasks;

namespace Banking.Persistence.Repositories.Interfaces
{
    public interface ICustomerRespository
    {
        Task<Customer> GetAsync(int Id);
    }
}