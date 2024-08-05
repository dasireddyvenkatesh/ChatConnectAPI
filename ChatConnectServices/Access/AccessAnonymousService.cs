using ChatConnectInterfaces.Access;

namespace ChatConnectServices.Access
{
    public class AccessAnonymousService : IAccessAnonymousService
    {
        public bool IsAnonymous(string requestedController, string requestedAction)
        {
            return (requestedController == "Public" && requestedAction == "Login");
        }
    }
}
