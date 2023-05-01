using FinanceTracker.Models;
using System.Linq.Expressions;

namespace FinanceTracker.Data.Interfaces
{
    public interface IBudgetRepository
    {
        ICollection<Budget> GetByUserId(int id);
        
        Budget GetOneById(int id);

        Budget Create(Budget budget);
        
        void IncreaseAmount(int id, float amount);

        void DecreaseAmount(int id, float amount);
    }
}
