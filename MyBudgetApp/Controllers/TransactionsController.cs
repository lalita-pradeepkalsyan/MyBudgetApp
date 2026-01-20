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

    }
}