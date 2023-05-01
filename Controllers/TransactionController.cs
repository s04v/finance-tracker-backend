using FinanceTracker.Enums;
using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [Route("api/budget/{budgetId}/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IBudgetService _budgetService;

        public TransactionController(ITransactionService transactionService, IBudgetService budgetService)
        {
            this._transactionService = transactionService;
            this._budgetService = budgetService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int budgetId)
        {
            var transaction = this._transactionService.GetByBudgetId(budgetId);
            if (transaction == null)
            {
                return NotFound("Not found");
            }
            return Ok(transaction);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetOne(int budgetId, int id)
        {
            var transaction = this._transactionService.GetOneById(id);
            if(transaction == null)
            {
                return NotFound("Not found");
            }

            return Ok(transaction);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(int budgetId, Transaction transaction)
        {
            var createdTransaction = this._transactionService.Create(transaction, budgetId);
            if(createdTransaction == null)
            {
                return BadRequest("Bad request");
            }
            return Ok(createdTransaction);
        }
    }
}
