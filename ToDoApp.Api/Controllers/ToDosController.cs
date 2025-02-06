using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Contracts.Requests.ToDo;
using ToDoApp.Api.Data.Repositories.ToDos;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDosController(ToDoContext context) : ControllerBase
{
    /// <summary>
    /// Gets all the To-Dos associated with the user.
    /// </summary>
    /// <param name="toDoRepository"></param>
    [HttpGet(Name = "Get ToDos")]
    public async Task<IResult> Get([FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId();
        var toDosList = await toDoRepository.GetAllAsync(userId);

        return Results.Ok(toDosList);
    }

    /// <summary>
    /// Creates a new To-Do.
    /// </summary>
    /// <param name="request"></param>
    [HttpPost]
    public async Task<IResult> Create(
        [FromBody] CreateToDoRequest request,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId();
        var user = await context.Users.FindAsync(userId);
        if (user == null)
            return Results.NotFound();
        var title = request.Title;
        var toDoItemsDto = request.Items;

        var toDoItems = toDoItemsDto.Select(toDoItemDto => new ToDoItem(toDoItemDto.Content)).ToList();

        var toDo = ToDo.Create(title, user, toDoItems);

        await context.ToDos.AddAsync(toDo);

        await toDoRepository.SaveChangesAsync();

        return Results.CreatedAtRoute(
            routeName: "Get ToDo",
            routeValues: new {toDoId = toDo.Id},
            value: toDo);
    }

    /// <summary>
    /// Gets a To-Do based on the given id.
    /// </summary>
    /// <param name="toDoId"></param>
    /// <param name="toDoRepository"></param>
    [HttpGet("{toDoId:int}", Name = "Get ToDo")]
    public async Task<IResult> Get(
        int toDoId,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId();
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);

        return Results.Ok(toDo);
    }

    /// <summary>
    /// Updates the To-Do specified by the id.
    /// </summary>
    /// <param name="toDoId"></param>
    /// <param name="request"></param>
    /// <param name="toDoRepository"></param>
    [HttpPut("{toDoId:int}")]
    public async Task<IResult> Update(int toDoId,
        [FromBody] UpdateToDoRequest request,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId(); 
        var title = request.Title;
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);
        
        if (toDo == null)
            return Results.NotFound();
        
        toDo.Update(title);
        
        await toDoRepository.SaveChangesAsync();

        return Results.Ok(toDo);
    }

    /// <summary>
    /// Deletes the specified, by its id, To-Do.
    /// </summary>
    /// <param name="toDoId"></param>
    /// <param name="toDoRepository"></param>
    /// <exception cref="DbUpdateException"></exception>
    [HttpDelete("{toDoId:int}")]
    public async Task<IResult> Delete(
        int toDoId,
        [FromServices] ToDoRepository toDoRepository)
    {
        var userId = HttpContext.GetRequiredUserId();
        var toDo = await toDoRepository.GetByIdAsync(toDoId, userId);
        if (toDo == null)
            return Results.NotFound();
        
        context.ToDos.Remove(toDo);
        
        await toDoRepository.SaveChangesAsync();
        
        return Results.Ok($"Successfully deleted ToDo with Id: {toDo.Id}!");
    }
}