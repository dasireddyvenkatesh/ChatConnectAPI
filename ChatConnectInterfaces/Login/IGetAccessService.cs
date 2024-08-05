using ChatConnectModels.Login;

namespace ChatConnectInterfaces.Login
{
    public interface IGetAccessService
    {
        public Task<List<ControllerMethodsModel>> Get(string userName);
    }
}
