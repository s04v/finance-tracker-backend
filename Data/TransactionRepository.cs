using FinanceTracker.Data.Interfaces;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context) 
        { 
            this._context = context;    
        }

        public Transaction Create(Transaction transaction)
        {
            this._context.Add(transaction);
            this._context.SaveChanges();

            return transaction;
        }

        public ICollection<Transaction> GetByBudgetId(int id)
        {
            return this._context.Transactions.Where(t => t.Budget.Id == id).Select(t => new Transaction
            {
                Id = t.Id,
                Amount = t.Amount,
                Type = t.Type,
                Category = t.Category,
                Time = t.Time
            }).ToList();
        }

        public Transaction GetOneById(int id)
        {
            return this._context.Transactions.Where(t => t.Id == id).Include(t => t.Budget).ThenInclude(b => b.User).FirstOrDefault();
        }
    }
}
