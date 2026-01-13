using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBudgetAppAPI.Data;
using MyBudgetAppAPI.Models.Repositories;

namespace MyBudgetAppAPI.Filters.ActionFilter
{
    public class Transaction_ValidateTransactionIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext _db;
        public Transaction_ValidateTransactionIdFilterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var transactionId = context.ActionArguments["transactionId"] as int?;

            if (transactionId.HasValue)
            {
                if (transactionId <= 0)
                {
                    context.ModelState.AddModelError("TransactionId", "Invalid transaction ID.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var transaction = _db.Transactions.Find(transactionId);

                    if (transaction == null)
                    {
                        context.ModelState.AddModelError("TransactionId", "Transaction ID does not exist");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status400BadRequest
                        };

                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["transaction"] = transaction;

                    }
                }
            }
        }

    }
}