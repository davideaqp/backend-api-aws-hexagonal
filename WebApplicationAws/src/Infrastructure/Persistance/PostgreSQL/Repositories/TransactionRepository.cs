using Microsoft.EntityFrameworkCore;
using WebApplicationAws.src.Domain.Repositories;
using WebApplicationAws.src.Domain.Transactions;

namespace WebApplicationAws.src.Infrastructure.Persistance.PostgreSQL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
            => await _context.Transaction.FindAsync(id);

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
            => await _context.Transaction
                            .Where(t => t.AccountId == accountId)
                            .ToListAsync();

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }

}
