using Microsoft.AspNetCore.Mvc;

namespace ChatConnect_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHubController : ControllerBase
    {
        [HttpPost("GetUserChatDetails")]
        public IActionResult GetUserChatDetails()
        {

            return Ok(/* return appropriate data */);
        }
    }
}
