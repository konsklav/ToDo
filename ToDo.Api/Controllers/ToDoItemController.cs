using Microsoft.AspNetCore.Mvc;

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
    public async Task<IResult> Create(int toDoId)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{itemId:int}")]
    public async Task<IResult> Update(int itemId, int toDoId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{itemId:int}")]
    public async Task<IResult> Delete(int itemId, int toDoId)
    {
        throw new NotImplementedException();
    }
}