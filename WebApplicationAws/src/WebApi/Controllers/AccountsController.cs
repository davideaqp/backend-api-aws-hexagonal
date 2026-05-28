using Microsoft.AspNetCore.Mvc;
using WebApplicationAws.src.Application.Accounts;
using WebApplicationAws.src.WebApi.DTOs;

namespace WebApplicationAws.src.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly CreateAccountUseCase _createAccount;
        private readonly GetAccountUseCase _getAccount;

        public AccountsController(CreateAccountUseCase createAccount, GetAccountUseCase getAccount)
        {
            _createAccount = createAccount;
            _getAccount = getAccount;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountDto dto)
        {
            var accountId = await _createAccount.ExecuteAsync(dto.OwnerName, dto.InitialBalance);
            return CreatedAtAction(nameof(GetById), new { id = accountId }, null);
        }

        // GET api/accounts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var account = await _getAccount.ExecuteAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }
    }
}
