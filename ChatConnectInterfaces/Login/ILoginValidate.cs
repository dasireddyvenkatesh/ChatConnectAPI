using ChatConnectModels.Login;

namespace ChatConnectInterfaces.Login
{
    public interface ILoginValidate
    {
        public Task<string> Validate(LoginModel loginModel);
    }
}
