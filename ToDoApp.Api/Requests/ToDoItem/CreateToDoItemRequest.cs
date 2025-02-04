namespace ToDoApp.Api.Requests.ToDoItem;

public sealed record CreateToDoItemRequest(
    string Name,
    bool IsDone);