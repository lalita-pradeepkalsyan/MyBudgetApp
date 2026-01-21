using Microsoft.AspNetCore.Mvc;
using MyBudgetApp.Data;
using MyBudgetApp.Models;

namespace MyBudgetApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IMyBudgetApiExecuter _myBudgetApiExecuter;
        public TransactionsController(IMyBudgetApiExecuter myBudgetApiExecuter)
        {
            _myBudgetApiExecuter = myBudgetApiExecuter;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _myBudgetApiExecuter.InvokeGet<List<Transaction>>("transactions"));
        }

        public IActionResult CreateTransaction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var response = await _myBudgetApiExecuter.InvokePost("Transactions", transaction);
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(transaction);
        }

        public async Task<IActionResult> UpdateTransaction(int transactionId)
        {
            var transaction = await _myBudgetApiExecuter.InvokeGet<Transaction>($"Transactions/{transactionId}");

            if (transaction != null)
            {
                return View(transaction);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransaction(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                await _myBudgetApiExecuter.InvokePut($"Transactions/{transaction.TransactionId}", transaction);
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

    }
}