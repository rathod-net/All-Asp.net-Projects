using Data.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Impletations;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IRepository<BankAccount> _accountRepository;

        public BankAccountController(IRepository<BankAccount> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var account = new BankAccount { UserId = userId, AccountNumber = GenerateAccountNumber(), Balance = 0 };

            await _accountRepository.AddAsync(account);
            await _accountRepository.SaveAsync();

            return Ok(account);
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var account = await _accountRepository.GetAllAsync();

            var userAccount = account.FirstOrDefault(a => a.UserId == userId);
            if (userAccount == null)
                return NotFound("Account not found.");

            return Ok(new { Balance = userAccount.Balance });
        }

        private string GenerateAccountNumber()
        {
            return $"BA{new Random().Next(100000, 999999)}";
        }
    }
}

