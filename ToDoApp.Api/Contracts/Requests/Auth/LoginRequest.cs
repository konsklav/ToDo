namespace ToDoApp.Api.Contracts.Requests.Auth;

public sealed record LoginRequest(string Username, string Password);