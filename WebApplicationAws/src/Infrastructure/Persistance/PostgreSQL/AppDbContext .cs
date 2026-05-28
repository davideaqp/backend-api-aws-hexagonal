using Microsoft.EntityFrameworkCore;
using WebApplicationAws.src.Domain.Accounts;
using WebApplicationAws.src.Domain.Transactions;

namespace WebApplicationAws.src.Infrastructure.Persistance.PostgreSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
