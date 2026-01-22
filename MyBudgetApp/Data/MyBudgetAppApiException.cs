using System.Text.Json;

namespace MyBudgetApp.Data
{
    public class MyBudgetAppApiException : Exception
    {
        public ErrorResponse? ErrorResponse { get; }

        public MyBudgetAppApiException(string errorJson)
        {
            ErrorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorJson);
        }

    }
}