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

        public async Task<T?> InvokePost<T>(string relativeurl, T obj)
        {
            var httpclient = _httpClientFactory.CreateClient(apiName);
            var response = await httpclient.PostAsJsonAsync(relativeurl, obj);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task InvokePut<T>(string relativeurl, T obj)
        {
            var httpclient = _httpClientFactory.CreateClient(apiName);
            var response = await httpclient.PutAsJsonAsync(relativeurl, obj);
            response.EnsureSuccessStatusCode();
        }


    }
}