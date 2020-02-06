using Banking.Business.Model;
using Banking.Persistence.Contexts;
using Banking.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Banking.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Transaction> GetAsync(int Id)
        {
            return await _context.Transactions
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

    }
}
