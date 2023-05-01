using FinanceTracker.Models;

namespace FinanceTracker.Services.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetByBudgetId(int id);

        Transaction GetOneById(int id);

        Transaction? Create(Transaction transaction, int budgetId);
    }
}
