namespace ToDo.Api.Models;

public class User
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    // Required for EFCore
    private User() { }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}