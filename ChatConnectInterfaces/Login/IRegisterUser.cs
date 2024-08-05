using ChatConnectModels.Login;

namespace ChatConnectInterfaces.Login
{
    public interface IRegisterUser
    {
       public Task<string> Register(RegisterModel registerModel);
    }
}
