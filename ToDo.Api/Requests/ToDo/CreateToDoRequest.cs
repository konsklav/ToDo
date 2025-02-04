namespace ToDo.Api.Requests.ToDo;

public sealed record CreateToDoRequest(
    string Title, IReadOnlyList<ToDoItemDto> Items);