using ChatConnectRepoModels;

namespace ChatConnectRepoInterfaces
{
    public interface IAccessRepo
    {
        public Task<int> ControllerExists(string controllerName);

        public Task<int> InsertController(Controllers controllers);
    }
}
