namespace ToDoApp.Api.Requests.ToDoItem;

public sealed record CreateToDoItemRequest(
    string Content,
    bool IsDone);