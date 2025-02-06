namespace ToDoApp.Api.Contracts.Requests.ToDoItem;

public sealed record UpdateToDoItemRequest(
    string Content,
    bool IsDone);