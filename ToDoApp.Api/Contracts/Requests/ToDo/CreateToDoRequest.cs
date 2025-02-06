namespace ToDoApp.Api.Contracts.Requests.ToDo;

public sealed record CreateToDoRequest(
    string Title, IReadOnlyList<ToDoItemDto> Items);