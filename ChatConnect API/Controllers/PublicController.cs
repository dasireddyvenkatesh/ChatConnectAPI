using ChatConnectConstants;
using ChatConnectInterfaces.Login;
using ChatConnectModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace ChatConnect_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly ILoginValidate _loginValidate;

        public PublicController(ILoginValidate loginValidate)
        {
            _loginValidate = loginValidate;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            if (ModelState.IsValid)
            {
                string message = await _loginValidate.Validate(loginModel);

                if (message != CommonConstants.LoginFailed)
                {
                    string cookieExistsMUID = Request.Cookies["MUID"] ?? string.Empty;
                    string cookieExistsGUID = Request.Cookies["GUID"] ?? string.Empty;

                    if (!string.IsNullOrEmpty(cookieExistsMUID) && !string.IsNullOrEmpty(cookieExistsGUID))
                    {
                        Response.Cookies.Delete("MUID");
                        Response.Cookies.Delete("GUID");
                    }

                    CookieOptions option = new CookieOptions();
                    option.SameSite = SameSiteMode.Strict;
                    option.Secure = true;
                    option.HttpOnly = true;
                    option.IsEssential = true;
                    option.Expires = DateTime.Now.AddDays(1);
                    int midpoint = message.Length / 2;
                    string firstHalf = message.Substring(0, midpoint);
                    string secondHalf = message.Substring(midpoint);
                    Response.Cookies.Append("MUID", firstHalf, option);
                    Response.Cookies.Append("GUID", secondHalf, option);

                    return Ok(CommonConstants.LoginSuccess);
                }
            }

            return Unauthorized(CommonConstants.LoginFailed);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterModel registerModel)
        {



            return Ok();
        }
    }
}
