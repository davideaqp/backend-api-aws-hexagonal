using Microsoft.AspNetCore.Mvc;
using WebApplicationAws.src.Application.Transactions;
using WebApplicationAws.src.WebApi.DTOs;

namespace WebApplicationAws.src.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly CreateTransactionUseCase _createTransaction;
        private readonly GetTransactionsByAccountUseCase _getTransactionsByAccount;

        public TransactionsController(
            CreateTransactionUseCase createTransaction,
            GetTransactionsByAccountUseCase getTransactionsByAccount)
        {
            _createTransaction = createTransaction;
            _getTransactionsByAccount = getTransactionsByAccount;
        }

        // POST api/transactions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            var transactionId = await _createTransaction.ExecuteAsync(
                dto.AccountId,
                dto.Amount,
                dto.Date,
                dto.Type
            );

            return CreatedAtAction(nameof(CreateTransaction), new { accountId = dto.AccountId }, null);
        }

        // GET api/transactions/create?accountId=...&amount=...&date=...&type=...
        [HttpGet("create")]
        public async Task<IActionResult> CreateTransaction(
            [FromQuery] Guid accountId,
            [FromQuery] decimal amount,
            [FromQuery] DateTime date,
            [FromQuery] string type)
        {
            try
            {
                var transactionId = await _createTransaction.ExecuteAsync(accountId, amount, date, type);
                return Ok(new { TransactionId = transactionId });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
