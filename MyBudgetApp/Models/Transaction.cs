using System.ComponentModel.DataAnnotations;

namespace MyBudgetApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        [Required]
        public DateOnly TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string? TransactionType { get; set; }

        //Title is like 'coffee' from receipt to find a category
        public string? Title { get; set; }
        public string? Category { get; set; }

        public string? Account { get; set; }
    }
}