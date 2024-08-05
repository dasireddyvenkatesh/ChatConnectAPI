using ChatConnectModels.Login;
using ChatConnectRepoClasses.Context;
using ChatConnectRepoInterfaces;
using ChatConnectRepoModels;
using Microsoft.EntityFrameworkCore;

namespace ChatConnectRepoClasses
{
    public class UserInfoRepo : IUserInfoRepo
    {
        private readonly AppDbContext _appDbContext;

        public UserInfoRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Users?> GetUser(string emailId)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == emailId);

            return user;
        }

        public async Task<List<ControllerMethodsModel>> GetControllerModelList(string emailId)
        {

            var user = await (from methods in _appDbContext.Methods
                              join controller in _appDbContext.Controllers on methods.ControllerId equals controller.ControllerId
                              join httptype in _appDbContext.HttpMethodType on methods.HttpTypeId equals httptype.TypeId
                              join userroles in _appDbContext.UserRoles on methods.RoleId equals userroles.RoleId
                              join users in _appDbContext.Users on userroles.UserId equals users.UserId
                              where users.Email == emailId
                              group new { controller, methods, httptype } by new
                              {
                                  controller.ControllerName,
                                  controller.IsAnonymous
                              } into grouped
                              select new ControllerMethodsModel
                              {
                                  ControllerModel = new ControllerModel
                                  {
                                      ControllerName = grouped.Key.ControllerName,
                                      IsAnonymous = grouped.Key.IsAnonymous,
                                  },
                                  Methods = grouped.Select(g => new MethodsModel
                                  {
                                      MethodName = g.methods.MethodName,
                                      MethodType = g.httptype.Type,
                                  }).ToList()
                              }).ToListAsync();

            return user != null ? user : new List<ControllerMethodsModel>();
        }
    }
}
