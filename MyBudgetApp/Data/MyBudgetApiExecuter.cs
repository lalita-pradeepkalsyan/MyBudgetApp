using System.Text.Json;

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
            //return await httpclient.GetFromJsonAsync<T>(relativeurl);

            var request = new HttpRequestMessage(HttpMethod.Get,relativeurl);
            var response = await httpclient.SendAsync(request);

            await HandlePotentialError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T?> InvokePost<T>(string relativeurl, T obj)
        {
            var httpclient = _httpClientFactory.CreateClient(apiName);
            var response = await httpclient.PostAsJsonAsync(relativeurl, obj);
            //response.EnsureSuccessStatusCode();

            await HandlePotentialError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task InvokePut<T>(string relativeurl, T obj)
        {
            var httpclient = _httpClientFactory.CreateClient(apiName);
            var response = await httpclient.PutAsJsonAsync(relativeurl, obj);

            await HandlePotentialError(response);
        }

        public async Task InvokeDelete(string relativeurl)
        {
            var httpclient = _httpClientFactory.CreateClient(apiName);
            var response = await httpclient.DeleteAsync(relativeurl);

            await HandlePotentialError(response);
        }

        private async Task HandlePotentialError(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                var errorJson = await httpResponse.Content.ReadAsStringAsync();
                //var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorJson);
                throw new MyBudgetAppApiException(errorJson);
            }

        }


    }
}