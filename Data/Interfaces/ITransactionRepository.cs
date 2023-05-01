using FinanceTracker.Models;

namespace FinanceTracker.Data.Interfaces
{
    public interface ITransactionRepository
    {
        ICollection<Transaction> GetByBudgetId(int id);

        Transaction GetOneById(int id);

        Transaction Create(Transaction transaction);
    }
}
