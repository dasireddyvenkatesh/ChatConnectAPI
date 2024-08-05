using ChatConnectRepoClasses.Context;
using ChatConnectRepoInterfaces;
using ChatConnectRepoModels;
using Microsoft.EntityFrameworkCore;

namespace ChatConnectRepoClasses
{
    public class AccessRepo : IAccessRepo
    {
        private readonly AppDbContext _appDbContext;

        public AccessRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> ControllerExists(string controllerName)
        {
            var exists = await _appDbContext.Controllers.Where(x =>x.ControllerName == controllerName).Select(x =>x.ControllerId).FirstOrDefaultAsync();

            return exists;
        }

        public async Task<int> InsertController(Controllers controllers)
        {
            await _appDbContext.AddAsync(controllers);

            int InsertId = _appDbContext.SaveChanges();

            return InsertId;
        }
    }
}
