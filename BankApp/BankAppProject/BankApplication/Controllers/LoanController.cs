using System.Security.Claims;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Impletations;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IRepository<Loan> _loanRepository;
        private readonly IRepository<BankAccount> _accountRepository;

        public LoanController(IRepository<Loan> loanRepository, IRepository<BankAccount> accountRepository)
        {
            _loanRepository = loanRepository;
            _accountRepository = accountRepository;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLoan([FromBody] LoanRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var account = (await _accountRepository.GetAllAsync()).FirstOrDefault(a => a.UserId == userId);

            if (account == null)
                return NotFound("Account not found.");

            var loan = new Loan
            {
                Id = account.Id,
                Amount = request.Amount,
                Status = "Pending",
            //    DueDate = DateTime.UtcNow.AddMonths(12)
            };

            await _loanRepository.AddAsync(loan);
            await _loanRepository.SaveAsync();

            return Ok(new { Message = "Loan application submitted.", LoanId = loan.Id });
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetLoanStatus()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loans = await _loanRepository.GetAllAsync();

            var userLoans = loans.Where(l => l.User.Id == userId);
            return Ok(userLoans);
        }
    }

    public class LoanRequest
    {
        public decimal Amount { get; set; }
    }
}

