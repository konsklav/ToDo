using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("todos/{toDoId:int}/items")]
public class ToDoItemController : ControllerBase
{
}