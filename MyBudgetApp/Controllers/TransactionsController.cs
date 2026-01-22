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
                try
                {
                    var response = await _myBudgetApiExecuter.InvokePost("Transactions", transaction);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (MyBudgetAppApiException ex)
                {
                    HandleApiExceptions(ex);

                }
            }
            return View(transaction);
        }

        public async Task<IActionResult> UpdateTransaction(int transactionId)
        {
            try
            {
                var transaction = await _myBudgetApiExecuter.InvokeGet<Transaction>($"Transactions/{transactionId}");

                if (transaction != null)
                {
                    return View(transaction);
                }
            }

            catch (MyBudgetAppApiException ex)
            {
                HandleApiExceptions(ex);
                return View();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransaction(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _myBudgetApiExecuter.InvokePut($"Transactions/{transaction.TransactionId}", transaction);
                    return RedirectToAction(nameof(Index));
                }
                catch (MyBudgetAppApiException ex)
                {
                    HandleApiExceptions(ex);
                }
            }
            return View(transaction);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteTransaction([FromForm] int transactionId)
        {
            try
            {
                await _myBudgetApiExecuter.InvokeDelete($"Transactions/{transactionId}");
                return RedirectToAction(nameof(Index));
            }
            catch (MyBudgetAppApiException ex)
            {
                HandleApiExceptions(ex);
                //return RedirectToAction(nameof(Index)); -- error will be lost
                return View(nameof(Index), await _myBudgetApiExecuter.InvokeGet<List<Transaction>>("transactions"));
            }


        }

        //If there are multiple controllers, this method should be in a controller(inheriting from controller class) as a protected method and this controller should be inheriting from that controller
        private void HandleApiExceptions(MyBudgetAppApiException ex)
        {
            if (ex.ErrorResponse != null && ex.ErrorResponse.Errors != null && ex.ErrorResponse.Errors.Count > 0)
            {
                foreach (var error in ex.ErrorResponse.Errors)
                {
                    ModelState.AddModelError(error.Key, string.Join("; ", error.Value));
                }
            }
        }

    }
}