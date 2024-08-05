namespace ChatConnectInterfaces.Access
{
    public interface IAccessAnonymousService
    {
        bool IsAnonymous(string requestedController, string requestedAction);
    }
}
