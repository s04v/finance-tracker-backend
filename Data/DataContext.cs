using FinanceTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
	public class DataContext : DbContext
	{

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions options) : base(options)
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql("Host=mouse.db.elephantsql.com;Port=5432;Database=trclzszf;Username=trclzszf;Password=8t-SBsoRSLL8QZ-Hg0oNYR4j2NaC6nZ2");

    }
}
