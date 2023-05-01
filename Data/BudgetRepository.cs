using FinanceTracker.Data.Interfaces;
using FinanceTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly DataContext _context;

        public BudgetRepository(DataContext context)
        {
            this._context = context;
        }

        public Budget Create(Budget budget)
        {
            this._context.Add(budget);
            this._context.SaveChanges();
            
            return budget;
        }

        public ICollection<Budget> GetByUserId(int id)
        {
            var user = this._context.Users.Where(u => u.Id == id).First();
            if(user == null)
            {
                return null;
            }

            return this._context.Budgets.Where(b => b.User == user).ToList();
        }

        public Budget GetOneById(int id)
        {
            return this._context.Budgets.Where(b => b.Id == id).Include(b => b.User).FirstOrDefault();
        }

        public void IncreaseAmount(int id, float amount)
        {
            var budget = this._context.Budgets.Where(b => b.Id == id).FirstOrDefault();
            budget.Amount += amount;
            this._context.SaveChanges();
        }

        public void DecreaseAmount(int id, float amount)
        {
            var budget = this._context.Budgets.Where(b => b.Id == id).FirstOrDefault();
            budget.Amount -= amount;
            this._context.SaveChanges();
        }
    }
}
