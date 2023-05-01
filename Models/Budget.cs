using System.Reflection.Metadata;

namespace FinanceTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Amount { get; set; }

        public User? User { get; set; }
    }

}
