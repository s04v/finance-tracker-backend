using FinanceTracker.Enums;

namespace FinanceTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        
        public int Amount { get; set; }

        public TransactionType Type { get; set; }

        public TransactionCategory Category { get; set; }

        public Budget? Budget { get; set; }

        public DateTime Time { get; set; }
    }
}
