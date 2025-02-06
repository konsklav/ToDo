using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Contracts.Requests.Auth;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class SignUpController(ToDoContext context) : ControllerBase
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="DbUpdateException"></exception>
    [HttpPost(Name = "Sign Up")]
    public async Task<IResult> Signup(SignUpRequest request)
    {
        var username = request.Username;
        var password = request.Password;

        var user = new User(username, password);
        
        await context.Users.AddAsync(user);
        
        try
        {
            await context.SaveChangesAsync();
        }
        catch
        {
            throw new DbUpdateException();
        }
        
        return Results.Ok(user);
    }
}