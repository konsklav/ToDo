using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Requests.ToDo;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDosController : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] CreateToDoRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{toDoId:int}")]
    public async Task<IResult> Get(int toDoId)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{toDoId:int}")]
    public async Task<IResult> Update(int toDoId, [FromBody] UpdateToDoRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{toDoId:int}")]
    public async Task<IResult> Delete(int toDoId)
    {
        throw new NotImplementedException();
    }
}