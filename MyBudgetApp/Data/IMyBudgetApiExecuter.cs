namespace MyBudgetApp.Data
{
    public interface IMyBudgetApiExecuter
    {
        public Task<T?> InvokeGet<T>(string relativeurl);
    }
}