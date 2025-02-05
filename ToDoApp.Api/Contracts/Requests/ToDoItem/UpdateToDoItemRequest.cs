namespace ToDoApp.Api.Requests.ToDoItem;

public sealed record UpdateToDoItemRequest(
    string Content,
    bool IsDone);