using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Contracts.Requests.ToDoItem;
using ToDoApp.Api.Data.Repositories.ToDos;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("todos/{toDoId:int}/items")]
public class ToDoItemController(ToDoContext context) : ControllerBase
{
    /// <summary>
    /// Checks the db for a ToDoItem with the given id in the specified, by its id, To-Do.
    /// </summary>
    /// <param name="toDoId"></param>
    /// <param name="itemId"></param>
    /// <param name="toDoRepository"></param>
    [HttpGet("{itemId:int}", Name = "Get ToDoItem")]
    public async Task<IResult> Get(
        int toDoId,
        int itemId,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId();
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);
        if (toDo == null)
            return Results.NotFound($"Couldn't find a ToDo with Id: {toDoId}");
        
        var toDoItems = toDo.Items;
        var toDoItem = toDoItems.FirstOrDefault(i => i.Id == itemId);
        if (toDoItem == null)
            return Results.NotFound($"Couldn't find a ToDoItem with Id: {itemId}");

        return Results.Ok(toDoItem);
    }

    /// <summary>
    /// Creates a new ToDoItem in the specified, by its id, To-Do.
    /// </summary>
    /// <param name="toDoId"></param>
    /// <param name="request"></param>
    [HttpPost]
    public async Task<IResult> Create(
        int toDoId,
        [FromBody] CreateToDoItemRequest request,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId(); 
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);
        if (toDo == null)
            return Results.NotFound($"Couldn't find a ToDo with Id: {toDoId}");

        var toDoItem = new ToDoItem(request.Content);
        
        toDo.AddItem(toDoItem);

        await toDoRepository.SaveChangesAsync();

        return Results.CreatedAtRoute(
            routeName: "Get ToDoItem",
            routeValues: new { toDoId = toDo.Id, itemId = toDoItem.Id },
            value: toDoItem);
    }

    /// <summary>
    /// Updates the specified, by its id, ToDoItem of the specified, by its id, To-Do.
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="toDoId"></param>
    /// <param name="request"></param>
    [HttpPut("{itemId:int}")]
    public async Task<IResult> Update(
        int itemId,
        int toDoId,
        [FromBody] UpdateToDoItemRequest request,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId(); 
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);
        if (toDo == null)
            return Results.NotFound($"Couldn't find a ToDo with Id: {toDoId}");
        
        var toDoItems = toDo.Items;
        var toDoItem = toDoItems.FirstOrDefault(i => i.Id == itemId);
        if (toDoItem == null)
            return Results.NotFound($"Couldn't find a ToDoItem with Id: {itemId}");
        
        toDoItem.Update(request.Content, request.IsDone);
        
        await toDoRepository.SaveChangesAsync();

        return Results.Ok(toDoItem);
    }

    /// <summary>
    /// Deletes the specified, by its id, ToDoItem of the specified by its id, To-Do.
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="toDoId"></param>
    [HttpDelete("{itemId:int}")]
    public async Task<IResult> Delete(
        int itemId,
        int toDoId,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId();
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);
        if (toDo == null)
            return Results.NotFound($"Couldn't find a ToDo with Id: {toDoId}");
        
        var toDoItems = toDo.Items;
        var toDoItem = toDoItems.FirstOrDefault(i => i.Id == itemId);
        if (toDoItem == null)
            return Results.NotFound($"Couldn't find a ToDoItem with Id: {itemId}");

        toDo.RemoveItem(toDoItem);
        
        await toDoRepository.SaveChangesAsync();

        return Results.Ok(toDoItem);
    }
}