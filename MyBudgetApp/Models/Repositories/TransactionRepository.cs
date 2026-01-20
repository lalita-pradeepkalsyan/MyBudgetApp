using System.Text.Json;
using MyBudgetApp.Models;

namespace MyBudgetApp.Models.Repositories
{
    public static class TransactionRepository
    {
        private static List<Transaction> transactions =
        [
            new()  {TransactionId = 1, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 100, TransactionType = "Debit",Category  = "Rent", Account ="MainAccount" },
            new()  {TransactionId = 2, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 20, TransactionType = "Debit",Category  = "Gas", Account ="MainAccount" },
            new()  {TransactionId = 3, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 1000, TransactionType = "Credit",Category  = "Salary", Account ="MainAccount" },
            new()  {TransactionId = 4, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 60, TransactionType = "Debit",Category  = "Groceries", Account ="MainAccount" },
            new()  {TransactionId = 5, TransactionDate = DateOnly.FromDateTime(DateTime.UtcNow), Amount = 30, TransactionType = "Debit",Category  = "Food", Account ="MainAccount" }
        ];


        public static bool TransactionExists(int transactionid)
        {
            return transactions.Any(x => x.TransactionId == transactionid);
        }

        public static Transaction? GetTransactionById(int transactionid)
        {
            return transactions.FirstOrDefault(x => x.TransactionId == transactionid);
        }

        public static List<Transaction> GetAllTransaction()
        {
            return transactions;
        }

        public static void CreateTransaction(Transaction transaction)
        {
            int maxId = transactions.Max(x => x.TransactionId);
            transaction.TransactionId = maxId + 1;

            transactions.Add(transaction);

        }

        public static void UpdateTransaction(Transaction transaction)
        {
            var transactionToUpdate = transactions.First(x => x.TransactionId == transaction.TransactionId);
            transactionToUpdate.Account = transaction.Account;
            transactionToUpdate.Amount = transaction.Amount;
            transactionToUpdate.Category = transaction.Category;
            transactionToUpdate.Title = transaction.Title;
            transactionToUpdate.TransactionType = transaction.TransactionType;
            transactionToUpdate.TransactionDate = transaction.TransactionDate;

        }

        public static void DeleteTransaction(int transactionid)
        {
            var transactionToDelete = transactions.First(x => x.TransactionId == transactionid);

            if (transactionToDelete != null)
                transactions.Remove(transactionToDelete);
        }
    }
}