namespace ToDoApp.Api.Models;

public class ToDo
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public User CreatedBy { get; private set; }
    public List<ToDoItem> ToDoItems { get; private set; }
    
    // Required for EFCore
    private ToDo() {}

    public ToDo(string title, User createdBy, List<ToDoItem> toDoItems, int id = 0)
    {
        Id = id;
        Title = title;
        CreatedBy = createdBy;
        ToDoItems = toDoItems;
    }

    public void Update(string title)
    {
        this.Title = title;
    }
}