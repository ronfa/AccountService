using Banking.Business.Model;
using Banking.Persistence.Contexts;
using Banking.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Banking.Persistence.Repositories
{
    public class CustomerRespository : BaseRepository, ICustomerRespository
    {
        public CustomerRespository(AppDbContext context) : base(context)
        {
        }

        public virtual async Task<Customer> GetAsync(int Id)
        {
            return await _context.Customers
                .AsNoTracking()
                .Include(m => m.Accounts)
                    .ThenInclude(a => a.Transactions)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

    }
}
