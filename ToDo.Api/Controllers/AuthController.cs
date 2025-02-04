using ToDo.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Requests.Auth;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
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