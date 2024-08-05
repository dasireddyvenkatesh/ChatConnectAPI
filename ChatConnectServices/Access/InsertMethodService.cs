using ChatConnectInterfaces.Access;
using ChatConnectModels.AccessSentry;
using ChatConnectRepoInterfaces;
using ChatConnectRepoModels;

namespace ChatConnectServices.Access
{
    public class InsertMethodService : IInsertMethodService
    {
        private readonly IRepoistory _repoistory;

        public InsertMethodService(IRepoistory repoistory)
        {
            _repoistory = repoistory;
        }


        public async Task<string> Insert(InsertMethodNameModel methodNameModel)
        {

            Methods methods = new Methods()
            {
                MethodName = methodNameModel.MethodName,
                ControllerId = methodNameModel.ControllerId,
                HttpTypeId = methodNameModel.HttpTypeId,
            };

            await _repoistory.AddItemAsync(methods);


            return "";
        }
    }
}
