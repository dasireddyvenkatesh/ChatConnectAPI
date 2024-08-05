namespace ChatConnectInterfaces.Access
{
    public interface IAccessCheckService
    {
        public bool IsAccess(string encrtptedData, string requestedController, string requestedAction, string methodType);
    }
}
