using ToDoApp.Api.Models;

namespace ToDoApp.Tests;

public class TodoTests
{
    private readonly User _user = new("Test", "User");
    private readonly List<ToDoItem> _items = [
        new("Apples", id: 0),
        new("Milk", id: 1),
        new("Shower Gel", id: 2)];
    
    [Fact]
    public void Create_ShouldCreateANewToDo()
    {
        // Act
        var toDo = ToDo.Create("Test", _user, []);

        // Assert
        Assert.NotNull(toDo);
        Assert.IsType<ToDo>(toDo);
    }
    
    [Fact]
    public void Update_ShouldUpdateTitle()
    {
        // Arrange
        const string newTitle = "Test 2";
        var todo = ToDo.Create("Test", _user, []);

        // Act
        todo.Update(newTitle);

        // Assert
        Assert.Equal(expected: newTitle, actual: todo.Title);
    }
    
    [Fact]
    public void AddItem_ShouldAddToDoItemInTheList()
    {
        // Arrange
        var todo = ToDo.Create("Test", _user, _items);
        var initialCount = todo.Items.Count;
        var newItem = new ToDoItem("Bananas", id: 3);
        
        // Act
        todo.AddItem(newItem);

        // Assert
        Assert.Equal(initialCount + 1, todo.Items.Count);
        Assert.Contains(newItem, todo.Items);
    }

    [Fact]
    public void RemoveItem_ShouldRemoveToDoItemFromList()
    {
        // Arrange
        var todo = ToDo.Create("Test", _user, _items);
        var initialCount = todo.Items.Count;
        var targetItem = new ToDoItem(_items[0].Content, id: _items[0].Id);
        
        // Act
        todo.RemoveItem(targetItem);

        // Assert
        Assert.Equal(initialCount - 1, todo.Items.Count);
        Assert.DoesNotContain(targetItem, todo.Items);
    }
}