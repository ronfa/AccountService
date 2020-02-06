using Banking.Business.Model;
using Banking.Services.Resources;
using System.Threading.Tasks;

namespace Banking.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerResource> GetAsync(int customerId);
    }
}