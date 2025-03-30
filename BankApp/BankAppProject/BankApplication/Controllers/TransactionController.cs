using Data.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Impletations;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<BankAccount> _accountRepository;

        public TransactionController(IRepository<Transaction> transactionRepository, IRepository<BankAccount> accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var account = (await _accountRepository.GetAllAsync()).FirstOrDefault(a => a.UserId == userId);

            if (account == null)
                return NotFound("Account not found.");

            account.Balance += request.Amount;
            _accountRepository.Update(account);
            await _accountRepository.SaveAsync();

            var transaction = new Transaction
            {
                BankAccountId = account.Id,
                Amount = request.Amount,
                Type = "Deposit"
            };

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveAsync();

            return Ok(new { Message = "Deposit successful.", Balance = account.Balance });
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var account = (await _accountRepository.GetAllAsync()).FirstOrDefault(a => a.UserId == userId);

            if (account == null)
                return NotFound("Account not found.");

            if (account.Balance < request.Amount)
                return BadRequest("Insufficient balance.");

            account.Balance -= request.Amount;
            _accountRepository.Update(account);
            await _accountRepository.SaveAsync();

            var transaction = new Transaction
            {
                BankAccountId = account.Id,
                Amount = request.Amount,
                Type = "Withdraw"
            };

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveAsync();

            return Ok(new { Message = "Withdrawal successful.", Balance = account.Balance });
        }
    }

    public class TransactionRequest
    {
        public decimal Amount { get; set; }
    }
}

