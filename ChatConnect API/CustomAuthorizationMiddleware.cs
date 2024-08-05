using ChatConnectInterfaces.Access;

namespace ChatConnect_API
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAccessCheckService _accessCheckService;

        public CustomAuthorizationMiddleware(RequestDelegate next, IAccessCheckService accessCheckService)
        {
            _next = next;
            _accessCheckService = accessCheckService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var requestedController = context.GetRouteValue("controller")?.ToString() ?? string.Empty;
                var requestedAction = context.GetRouteValue("action")?.ToString() ?? string.Empty;
                var methodType = context.Request.Method.ToString() ?? string.Empty;

                var encryptedData = context.Request.Cookies["MUID"] + context.Request.Cookies["GUID"] ?? string.Empty;

                bool isAllowed = _accessCheckService.IsAccess(encryptedData, requestedController, requestedAction, methodType);

                if (!isAllowed)
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Access denied: You do not have permission to access this resource. Please log in if you haven't already.");
                    return;
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}
