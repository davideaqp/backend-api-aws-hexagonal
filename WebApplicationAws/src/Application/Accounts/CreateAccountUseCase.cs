using WebApplicationAws.src.Domain.Accounts;
using WebApplicationAws.src.Domain.Repositories;

namespace WebApplicationAws.src.Application.Accounts
{
    public class CreateAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Guid> ExecuteAsync(string ownerName, decimal initialBalance)
        {
            // Crear entidad con Value Object Money
            var account = new Account(
                Guid.NewGuid(),
                ownerName,
                new Money(initialBalance)
            );

            // Persistir usando el repositorio
            await _accountRepository.AddAsync(account);

            return account.Id;
        }
    }
}

