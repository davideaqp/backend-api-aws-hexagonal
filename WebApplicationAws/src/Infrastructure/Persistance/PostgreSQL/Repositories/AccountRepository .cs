using Microsoft.EntityFrameworkCore;
using WebApplicationAws.src.Domain.Accounts;
using WebApplicationAws.src.Domain.Repositories;

namespace WebApplicationAws.src.Infrastructure.Persistance.PostgreSQL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetByIdAsync(Guid id)
            => await _context.Accounts.FindAsync(id);

        public async Task<IEnumerable<Account>> GetAllAsync()
            => await _context.Accounts.ToListAsync();

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }

}
