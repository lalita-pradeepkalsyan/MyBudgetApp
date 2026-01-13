using MyBudgetAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBudgetAppAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TransactionId)
                .UseIdentityAlwaysColumn();

            modelBuilder.Entity<Transaction>().HasData(
            new { TransactionId = 1, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 100.00, TransactionType = "Debit", Category = "Rent", Account = "MainAccount" },
            new { TransactionId = 2, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 20.00, TransactionType = "Debit", Category = "Gas", Account = "MainAccount" },
            new { TransactionId = 3, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 1000.00, TransactionType = "Credit", Category = "Salary", Account = "MainAccount" },
            new { TransactionId = 4, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 60.00, TransactionType = "Debit", Category = "Groceries", Account = "MainAccount" },
            new { TransactionId = 5, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 30.00, TransactionType = "Debit", Category = "Food", Account = "MainAccount" }
            );
        }
    }
}