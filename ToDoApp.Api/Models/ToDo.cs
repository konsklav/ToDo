namespace ToDoApp.Api.Models;

public class ToDo
{
    private readonly List<ToDoItem> _toDoItems;
    
    public int Id { get; private set; }
    public string Title { get; private set; }
    public User CreatedBy { get; private set; }
    public IReadOnlyList<ToDoItem> ToDoItems => _toDoItems;
    
    // Required for EFCore
    private ToDo() {}

    private ToDo(string title, User createdBy, List<ToDoItem> toDoItems, int id = 0)
    {
        Id = id;
        Title = title;
        CreatedBy = createdBy;
        _toDoItems = toDoItems;
    }

    public static ToDo Create(string title, User createdBy, List<ToDoItem> toDoItems)
    {
        return new ToDo(title, createdBy, toDoItems);
    }
    
    public void Update(string title)
    {
        Title = title;
    }

    public void AddItem(ToDoItem toDoItem)
    {
        _toDoItems.Add(toDoItem);
    }

    public void RemoveItem(ToDoItem toDoItem)
    {
        _toDoItems.Remove(toDoItem);
    }
}