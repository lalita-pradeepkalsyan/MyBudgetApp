namespace MyBudgetApp.Data
{
    public class MyBudgetApiExecuter : IMyBudgetApiExecuter
    {
        private const string apiName = "TransactionsApi";
        private readonly IHttpClientFactory _httpClientFactory;
        public MyBudgetApiExecuter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> InvokeGet<T>(string relativeurl)
        {
            var httpclient = _httpClientFactory.CreateClient(apiName);
            return await httpclient.GetFromJsonAsync<T>(relativeurl);
        }
    }
}