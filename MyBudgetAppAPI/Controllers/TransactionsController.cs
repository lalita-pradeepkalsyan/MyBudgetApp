using MyBudgetAppAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyBudgetAppAPI.Models;
using MyBudgetAppAPI.Filters.ActionFilter;
using MyBudgetAppAPI.Data;

namespace MyBudgetAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public TransactionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            return Ok(_db.Transactions.ToList());
        }

        [HttpGet("{transactionid}")]
        [TypeFilter(typeof(Transaction_ValidateTransactionIdFilterAttribute))]
        public IActionResult GetTransactionById(int transactionId)
        {
            //One of the option, but we are contacting db twice
            //return Ok(_db.Transactions.Find(transactionId));

            //Another option to get the shirt from the action filter , where we contacted db
            return Ok(HttpContext.Items["transaction"]);
        }

        [HttpPost]
        public IActionResult CreateTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null)
                return BadRequest();

            //If you must keep the property as a DateTime, you need to ensure the Kind is set to Utc before saving.
            //transaction.TransactionDate = transaction.TransactionDate.ToUniversalTime();

            _db.Transactions.Add(transaction);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetTransactionById),
            new { transactionid = transaction.TransactionId }, transaction
            );
        }

        [HttpPut("{transactionid}")]
        [TypeFilter(typeof(Transaction_ValidateTransactionIdFilterAttribute))]
        public IActionResult UpdateTransaction(int transactionid, [FromBody] Transaction transaction)
        {
            if (transactionid != transaction.TransactionId)
                return BadRequest("Id provided is not same as transaction ID");
            try
            {
                var transactionToUpdate = HttpContext.Items["transaction"] as Transaction;

                transactionToUpdate.Account = transaction.Account;
                transactionToUpdate.Amount = transaction.Amount;
                transactionToUpdate.Category = transaction.Category;
                transactionToUpdate.Title = transaction.Title;
                transactionToUpdate.TransactionType = transaction.TransactionType;
                transactionToUpdate.TransactionDate = transaction.TransactionDate;
            }
            catch
            {
                if (_db.Transactions.Find(transactionid) == null)
                    return NotFound();
                throw;
            }

            _db.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{transactionid}")]
        [TypeFilter(typeof(Transaction_ValidateTransactionIdFilterAttribute))]
        public IActionResult DeleteTransaction(int transactionid)
        {
            var transactionToDelete = HttpContext.Items["transaction"] as Transaction;

            _db.Transactions.Remove(transactionToDelete);
            _db.SaveChanges();

            return Ok(transactionToDelete);
        }


    }
}