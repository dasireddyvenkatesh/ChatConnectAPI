using ChatConnectInterfaces.Access;
using ChatConnectRepoInterfaces;
using ChatConnectRepoModels;

namespace ChatConnectServices.Access
{
    public class InsertControllerName : IInsertControllerName
    {
        private readonly IAccessRepo _accessRepo;

        public InsertControllerName(IAccessRepo accessRepo)
        {
            _accessRepo = accessRepo;
        }

        public async Task<string> Name(string controllerName)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(controllerName))
            {
                return message = "Controller Name Cannot Be Blank";
            }

            int exists = await _accessRepo.ControllerExists(controllerName);

            if (exists > 0)
            {
                return message = "Controller Name Already Exists";
            }

            Controllers controllers = new Controllers() { ControllerName = controllerName };

            int insertId = await _accessRepo.InsertController(controllers);

            if (insertId > 0)
            {
                message = "Controller Name Inserted Succesfully";
            }

            return message;

        }
    }
}
