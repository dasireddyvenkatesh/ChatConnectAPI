using ChatConnectModels.Login;

namespace ChatConnectInterfaces.Login
{
    public interface ILoginCheck
    {
        public Task<string> Login(LoginModel loginModel);
    }
}
