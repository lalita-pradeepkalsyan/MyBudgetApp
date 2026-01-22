namespace MyBudgetApp.Data
{
    public interface IMyBudgetApiExecuter
    {
        public Task<T?> InvokeGet<T>(string relativeurl);
        public Task<T?> InvokePost<T>(string relativeurl, T obj);
        public Task InvokePut<T>(string relativeurl, T obj);
        public Task InvokeDelete(string relativeurl);
    }
}