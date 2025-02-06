using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Contracts.Requests.Auth;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthController(ToDoContext context) : ControllerBase
{
    /// <summary>
    /// Checks the db for a user with the specified credentials.
    /// </summary>
    /// <param name="request"></param>
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest request)
    {
        var username = request.Username;
        var password = request.Password;

        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        if(user is null)
            return Results.Unauthorized();
        
        HttpContext.Session.SetInt32(TodoConstants.SessionUserId, user.Id);
        return Results.Ok(user);
    }

    [HttpGet("logout")]
    public async Task<IResult> Logout()
    {
        HttpContext.Session.Remove(TodoConstants.SessionUserId);
        return Results.Ok();
    }
}