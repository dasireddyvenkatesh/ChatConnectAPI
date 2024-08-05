using ChatConnectInterfaces.Login;
using ChatConnectModels.Login;
using ChatConnectRepoInterfaces;

namespace ChatConnectServices.Login
{
    public class GetAccessService : IGetAccessService
    {
        private readonly IUserInfoRepo _userInfoRepo;

        public GetAccessService(IUserInfoRepo userInfoRepo)
        {
            _userInfoRepo = userInfoRepo;
        }
        
        public async Task<List<ControllerMethodsModel>> Get(string userName)
        {

            var controllerMethods = await _userInfoRepo.GetControllerModelList("dasireddyvenkatesh@gmail.com");

            return controllerMethods;
        }
    }
}
