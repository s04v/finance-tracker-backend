using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            this._budgetService = budgetService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._budgetService.GetByUserId());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var budget = this._budgetService.GetOneById(id);
            if(budget == null)
            {
                return NotFound("Not found");
            }

            return Ok(budget);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Budget budget)
        {
            var createdBudget = this._budgetService.Create(budget);
            if(createdBudget == null)
            {
                return BadRequest("Bad request");
            }

            return Ok(createdBudget);
        }
    }
}
