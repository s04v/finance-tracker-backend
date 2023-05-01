using FinanceTracker.Models;

namespace FinanceTracker.Services.Interfaces
{
    public interface IBudgetService
    {
        IEnumerable<Budget> GetByUserId();

        Budget GetOneById(int id);

        Budget? Create(Budget budget);
    }
}
