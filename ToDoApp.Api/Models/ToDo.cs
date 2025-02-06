namespace ToDoApp.Api.Models;

public class ToDo
{
    private readonly List<ToDoItem> _items;
    
    public int Id { get; private set; }
    public string Title { get; private set; }
    public User CreatedBy { get; private set; }
    public IReadOnlyList<ToDoItem> Items => _items;
    
    // Required for EFCore
    private ToDo() {}

    private ToDo(string title, User createdBy, List<ToDoItem> items, int id = 0)
    {
        Id = id;
        Title = title;
        CreatedBy = createdBy;
        _items = items;
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
        _items.Add(toDoItem);
    }

    public void RemoveItem(ToDoItem toDoItem)
    {
        var item = _items.FirstOrDefault(item => item.Id == toDoItem.Id);
        if (item != null)
            _items.Remove(item);
    }
}