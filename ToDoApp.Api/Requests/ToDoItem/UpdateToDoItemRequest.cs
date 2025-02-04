namespace ToDoApp.Api.Requests.ToDoItem;

public sealed record UpdateToDoItemRequest(
    string? Content = null,
    bool? IsDone = null);