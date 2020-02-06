using Banking.Business.Model;
using Banking.Persistence.Contexts;
using Banking.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Banking.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Account> GetAsync(int Id)
        {
            return await _context.Accounts
                .AsNoTracking()
                .Include(t => t.Transactions)
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }
    }
}
