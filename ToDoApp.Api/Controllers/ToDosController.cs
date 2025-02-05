using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Models;
using ToDoApp.Api.Requests.ToDo;
using ToDoApp.Api.UseCases.ToDos;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDosController(ToDoContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get([FromServices] ToDoQueries toDoQueries)
    {
        var userId = 1; // temp --> needs session management
        var toDosList = await toDoQueries.GetAllAsync(userId);

        return Results.Ok(toDosList);
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] CreateToDoRequest request)
    {
        var user = new User("test", "test"); // temp --> needs session management
        var title = request.Title;
        var toDoItemsDto = request.Items;

        var toDoItems = toDoItemsDto.Select(toDoItemDto => new ToDoItem(toDoItemDto.Content)).ToList();

        var toDo = new ToDo(title, user, toDoItems);

        await context.ToDos.AddAsync(toDo);

        try
        {
            await context.SaveChangesAsync();
        }
        catch
        {
            throw new DbUpdateException();
        }

        return Results.Ok(toDo);
    }

    [HttpGet("{toDoId:int}")]
    public async Task<IResult> Get(
        int toDoId,
        [FromServices] ToDoQueries toDoQueries)
    {
        var userId = 1; // temp --> needs session management
        var toDo = await toDoQueries.GetByIdAsync(toDoId, userId);

        return Results.Ok(toDo);
    }

    [HttpPut("{toDoId:int}")]
    public async Task<IResult> Update(int toDoId,
        [FromBody] UpdateToDoRequest request,
        [FromServices] ToDoQueries toDoQueries)
    {
        var userId = 1; // temp --> needs session management
        var title = request.Title;
        var toDo = await toDoQueries.GetByIdAsync(toDoId, userId);
        
        if (toDo == null)
            return Results.NotFound();
        
        toDo.Update(title);
        
        try
        {
            await context.SaveChangesAsync();
        }
        catch
        {
            throw new DbUpdateException();
        }

        return Results.Ok(toDo);
    }

    [HttpDelete("{toDoId:int}")]
    public async Task<IResult> Delete(
        int toDoId,
        [FromServices] ToDoQueries toDoQueries)
    {
        var userId = 1; // temp --> needs session management
        var toDo = await toDoQueries.GetByIdAsync(toDoId, userId);
        if (toDo == null)
            return Results.NotFound();
        
        context.ToDos.Remove(toDo);
        
        try
        {
            await context.SaveChangesAsync();
        }
        catch
        {
            throw new DbUpdateException();
        }
        
        return Results.Ok($"Successfully deleted ToDo with Id: {toDo.Id}!");
    }
}