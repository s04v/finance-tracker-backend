using FinanceTracker.Data.Interfaces;
using FinanceTracker.Models;
using FinanceTracker.Providers;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUserProvider _userProvider;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBudgetRepository _budgetRepository;

        public TransactionService(IUserProvider userProvider, ITransactionRepository transactionRepository, IBudgetRepository budgetRepository) 
        { 
            this._userProvider = userProvider;
            this._transactionRepository = transactionRepository;
            this._budgetRepository = budgetRepository;
        }

        public Transaction? Create(Transaction transaction, int budgetId)
        {
            int userId = this._userProvider.GetId();
            var budget = this._budgetRepository.GetOneById(budgetId);
            if (budget == null || budget.User.Id != userId)
            {
                return null;
            }

            if(transaction.Type == Enums.TransactionType.Income) 
            {
                this._budgetRepository.IncreaseAmount(budgetId, transaction.Amount);
            } else
            {
                this._budgetRepository.DecreaseAmount(budgetId, transaction.Amount);
            }

            transaction.Budget = budget;
            transaction.Time = DateTime.Now;
            return this._transactionRepository.Create(transaction);
        }

        public IEnumerable<Transaction> GetByBudgetId(int id)
        {
            int userId = this._userProvider.GetId();
            var budget = this._budgetRepository.GetOneById(id);
            if (budget == null || budget.User.Id != userId)
            {
                return null;
            }

            return this._transactionRepository.GetByBudgetId(id);
        }

        public Transaction GetOneById(int id)
        {
            int userId = this._userProvider.GetId();
            var transaction = this._transactionRepository.GetOneById(id);
            if (transaction == null || transaction.Budget.User.Id != userId)
            {
                return null;
            }
            transaction.Budget = null;
            return transaction;
        }
    }
}
