using ChatConnectModels.AccessSentry;

namespace ChatConnectInterfaces.Access
{
    public interface IInsertMethodService
    {
        public Task<string> Insert(InsertMethodNameModel methodNameModel);
    }
}
