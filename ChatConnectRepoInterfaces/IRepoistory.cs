namespace ChatConnectRepoInterfaces
{
    public interface IRepoistory
    {
        public Task<int> AddItemAsync<T>(T item) where T : class;
    }
}
