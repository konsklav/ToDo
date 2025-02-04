using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Requests.ToDoItem;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("todos/{toDoId:int}/items")]
public class ToDoItemController : ControllerBase
{
    [HttpGet("{itemId:int}")]
    public async Task<IResult> Get(int itemId, int toDoId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IResult> Create(int toDoId, [FromBody] CreateToDoItemRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{itemId:int}")]
    public async Task<IResult> Update(int itemId, int toDoId, [FromBody] UpdateToDoItemRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{itemId:int}")]
    public async Task<IResult> Delete(int itemId, int toDoId)
    {
        throw new NotImplementedException();
    }
}