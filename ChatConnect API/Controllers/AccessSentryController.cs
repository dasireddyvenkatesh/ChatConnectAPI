using ChatConnectInterfaces.Access;
using ChatConnectModels.AccessSentry;
using Microsoft.AspNetCore.Mvc;

namespace ChatConnect_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessSentryController : ControllerBase
    {
        private readonly IInsertControllerName _insertControllerName;
        private readonly IInsertMethodService _insertMethodService;

        public AccessSentryController(IInsertControllerName insertControllerName, IInsertMethodService insertMethodService)
        {
            _insertControllerName = insertControllerName;
            _insertMethodService = insertMethodService;
        }


        [HttpPost("InsertControllerName")]
        public async Task<IActionResult> InsertControllerName(string controllerName)
        {
            string message = await _insertControllerName.Name(controllerName);

            return Ok(message);
        }

        [HttpPost("InsertMethodName")]
        public async Task<IActionResult> InsertMethodName(InsertMethodNameModel methodNameModel)
        {
            string message = await _insertMethodService.Insert(methodNameModel);

            return Ok(message);
        }

    }
}
