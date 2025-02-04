namespace ToDo.Api.Models;

public class ToDoItem
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsDone { get; private set; }
    
    // Required for EFCore
    private ToDoItem() { }

    public ToDoItem(string name, bool isDone, int id = 0)
    {
        Id = id;
        Name = name;
        IsDone = isDone;
    }
}