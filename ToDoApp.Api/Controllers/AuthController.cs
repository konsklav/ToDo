using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Requests.Auth;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(ToDoContext context) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpGet("logout")]
    public async Task<IResult> Logout()
    {
        throw new NotImplementedException();
    }
}