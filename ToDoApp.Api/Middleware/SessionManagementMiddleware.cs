namespace ToDoApp.Api.Middleware;

internal sealed class SessionManagementMiddleware : IMiddleware
{
    private readonly string[] _whitelist = ["/", "/auth/login", "/signup"];

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (_whitelist.Contains(context.Request.Path.Value?.ToLower()))
        {
            await next(context);
            return;
        }

        var userId = context.Session.GetInt32(TodoConstants.SessionUserId);
        if (!userId.HasValue)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("This endpoint requires a session. Please ensure you have" +
                                              "a session cookie in your HTTP headers. If not, go to /auth/login to obtain one.");
            return;
        }

        await next(context);
    }
}