using ChatConnectInterfaces.Access;
using ChatConnectInterfaces.Login;
using ChatConnectModels.Login;
using System.Text.Json;

namespace ChatConnectServices.Login
{
    public class LoginValidate : ILoginValidate
    {
        private readonly IGetAccessService _accessService;
        private readonly IEncryptionService _encryptionService;

        public LoginValidate(IGetAccessService accessService, IEncryptionService encryptionService)
        {
            _accessService = accessService;
            _encryptionService = encryptionService;
        }
        public async Task<string> Validate(LoginModel loginModel)
        {

            string message = string.Empty;

            //Check Login is valid 
            bool isValidLogin = true;

            //if valid login get all the acccess
            if (isValidLogin)
            {
                List<ControllerMethodsModel> controllerMethods = await _accessService.Get(loginModel.UserName);

                string jsonContollerMethod = JsonSerializer.Serialize(controllerMethods);

                message = _encryptionService.Encrypt(jsonContollerMethod);

                //var a = _encryptionService.Decrypt(message);

            }


            return message;
        }
    }
}
