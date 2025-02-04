namespace ToDoApp.Api.Requests.ToDoItem;

public sealed record UpdateToDoItemRequest(
    string? Name = null,
    bool? IsDone = null);