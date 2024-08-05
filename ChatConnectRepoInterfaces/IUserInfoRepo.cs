using ChatConnectModels.Login;
using ChatConnectRepoModels;

namespace ChatConnectRepoInterfaces
{
    public interface IUserInfoRepo
    {
        public Task<Users?> GetUser(string emailId);

        public Task<List<ControllerMethodsModel>> GetControllerModelList(string emailId);
    }
}
