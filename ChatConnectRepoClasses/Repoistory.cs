using ChatConnectRepoClasses.Context;
using ChatConnectRepoInterfaces;

namespace ChatConnectRepoClasses
{
    public class Repoistory : IRepoistory
    {
        private readonly AppDbContext _appDbContext;

        public Repoistory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> AddItemAsync<T>(T item) where T : class
        {
            await _appDbContext.AddAsync(item);

            int InsertId = await _appDbContext.SaveChangesAsync();

            return InsertId;
        }
    }
}
