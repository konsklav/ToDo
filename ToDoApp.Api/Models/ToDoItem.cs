namespace ToDoApp.Api.Models;

public class ToDoItem
{
    public int Id { get; private set; }
    public string Content { get; private set; }
    public bool IsDone { get; private set; }
    
    // Required for EFCore
    private ToDoItem() { }

    public ToDoItem(string content, bool isDone = false, int id = 0)
    {
        Id = id;
        Content = content;
        IsDone = isDone;
    }
}