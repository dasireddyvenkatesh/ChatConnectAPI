using ChatConnectInterfaces.Access;
using ChatConnectModels.Login;
using System.Text.Json;

namespace ChatConnectServices.Access
{
    public class AccessCheckService : IAccessCheckService
    {
        private readonly IEncryptionService _encryptionService;
        private readonly IAccessAnonymousService _accessAnonymousService;

        public AccessCheckService(IEncryptionService encryptionService, IAccessAnonymousService accessAnonymousService)
        {
            _encryptionService = encryptionService;
            _accessAnonymousService = accessAnonymousService;
        }

        public bool IsAccess(string encryptedData, string requestedController, string requestedAction, string methodType)
        {

            bool isAnonymous = _accessAnonymousService.IsAnonymous(requestedController, requestedAction);

            if (isAnonymous)
                return isAnonymous;

            if (string.IsNullOrEmpty(encryptedData))
                return false;

            var decryptedJson = _encryptionService.Decrypt(encryptedData);

            var controllerMethodsList = JsonSerializer.Deserialize<List<ControllerMethodsModel>>(decryptedJson);

            if (controllerMethodsList == null || !controllerMethodsList.Any())
                return false;

            //return controllerMethodsList.Where(x => x.ControllerName == requestedController)
                    //.SelectMany(x => x.MethodNames).Any(methodName => methodName.Contains(requestedAction));


            var methods = controllerMethodsList.FirstOrDefault(cm => cm.ControllerModel.ControllerName == requestedController)?.Methods;

            if (methods == null || !methods.Any())
                return false;

            return methods.Any(m => m.MethodName == requestedAction && m.MethodType == methodType);
        }
    }
}
