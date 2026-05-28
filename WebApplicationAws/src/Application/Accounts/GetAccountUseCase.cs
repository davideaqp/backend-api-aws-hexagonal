using WebApplicationAws.src.Domain.Accounts;
using WebApplicationAws.src.Domain.Repositories;

namespace WebApplicationAws.src.Application.Accounts
{
    public class GetAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account?> ExecuteAsync(Guid accountId)
        {
            // Recuperar la cuenta desde el repositorio
            var account = await _accountRepository.GetByIdAsync(accountId);

            // Aquí podrías aplicar reglas adicionales (ej. validaciones, auditoría)
            return account;
        }
    }
}

