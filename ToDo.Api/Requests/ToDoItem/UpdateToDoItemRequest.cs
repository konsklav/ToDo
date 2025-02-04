namespace ToDo.Api.Requests.ToDoItem;

public sealed record UpdateToDoItemRequest(
    string? Name = null,
    bool? IsDone = null,
    int? NewToDoId = null);