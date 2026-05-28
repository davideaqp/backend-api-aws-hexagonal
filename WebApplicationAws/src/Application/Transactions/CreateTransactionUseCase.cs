using WebApplicationAws.src.Domain.Transactions;
using WebApplicationAws.src.Domain.Repositories;

namespace WebApplicationAws.src.Application.Transactions
{
    public class CreateTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public CreateTransactionUseCase(
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
            _accountRepository = accountRepository
                ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Guid> ExecuteAsync(Guid accountId, decimal amount, DateTime date, string type)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) throw new InvalidOperationException("Account not found");

            // Aplicar lógica de negocio según tipo de transacción
            if (type.Equals("Deposit", StringComparison.OrdinalIgnoreCase))
            {
                account.Deposit(amount);
            }
            else if (type.Equals("Withdraw", StringComparison.OrdinalIgnoreCase))
            {
                account.Withdraw(amount);
            }
            else
            {
                throw new ArgumentException("Invalid transaction type");
            }

            // Crear transacción usando el constructor de la entidad
            var transaction = new Transaction(accountId, amount, date, type);

            await _transactionRepository.AddAsync(transaction);
            await _accountRepository.UpdateAsync(account);

            return transaction.Id;
        }
    }
}
