using FinanceTracker.Data.Interfaces;
using FinanceTracker.Models;
using FinanceTracker.Providers;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserRepository _userRepository;
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IUserProvider userProvider, IBudgetRepository budgetRepository, IUserRepository userRepository)
        {
            this._userProvider = userProvider;
            this._budgetRepository = budgetRepository;
            this._userRepository = userRepository;
        }

        public Budget? Create(Budget budget)
        {
            int userId = this._userProvider.GetId();
            var user = this._userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            budget.User = user;
            return this._budgetRepository.Create(budget);
        }

        public IEnumerable<Budget> GetByUserId()
        {
            int userId = this._userProvider.GetId();
            return this._budgetRepository.GetByUserId(userId);
        }

        public Budget GetOneById(int id)
        {
            int userId = this._userProvider.GetId();
            var budget = this._budgetRepository.GetOneById(id);
            if (budget == null || budget?.User?.Id != userId)
            {
                return null;
            }

            return budget;
        }
    }
}
