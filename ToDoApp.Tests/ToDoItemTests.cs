using ToDoApp.Api.Models;

namespace ToDoApp.Tests;

public class ToDoItemTests
{
    private readonly User _user = new("Test", "User");
    private readonly List<ToDoItem> _items = [
        new("Apples", id: 0),
        new("Milk", id: 1),
        new("Shower Gel", id: 2)];
    
    [Fact]
    public void Update_ShouldUpdateContentAndIsDoneState()
    {
        // Arrange
        const string newContent = "Tomatoes";
        var item = _items.First();

        // Act
        item.Update(newContent, true);

        // Assert
        Assert.Equal(expected: newContent, actual: item.Content);
        Assert.True(item.IsDone);
    }
}