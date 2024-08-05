using ChatConnectConstants;
using ChatConnectInterfaces.Login;
using ChatConnectModels.Login;
using ChatConnectRepoInterfaces;
using ChatConnectRepoModels;

namespace ChatConnectServices.Login
{
    public class LoginCheck : ILoginCheck
    {
        private readonly IUserInfoRepo _userInfoRepo;

        public LoginCheck(IUserInfoRepo userInfoRepo)
        {
            _userInfoRepo = userInfoRepo;
        }

        public async Task<string> Login(LoginModel loginModel)
        {

            string message = string.Empty;

            Users? users = await _userInfoRepo.GetUser(loginModel.UserName);

            if (users == null)
            {
                message = CommonConstants.LoginFailed;

                return message;
            }




            return message;

        }
    }
}
