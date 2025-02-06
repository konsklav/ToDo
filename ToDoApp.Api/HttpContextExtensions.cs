namespace ToDoApp.Api;

internal static class HttpContextExtensions
{
    public static int GetRequiredUserId(this HttpContext context) => 
        context.Session.GetInt32(TodoConstants.SessionUserId)
        ?? throw new InvalidOperationException("Couldn't find user ID in session. Please ensure you have middleware to" +
                                               "check for session IDs.");
}