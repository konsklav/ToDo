namespace ToDoApp.Api.Models;

public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    
    public const int MaxUsernameLength = 32;
    public const int MaxPasswordLength = 128;

    // Required for EFCore
    private User() { }

    public User(string username, string password, int id = 0)
    {
        Id = id;
        Username = username;
        Password = password;
    }
}