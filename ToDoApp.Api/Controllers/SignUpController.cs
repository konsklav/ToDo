using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Models;
using ToDoApp.Api.Requests.Auth;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SignUpController(ToDoContext context) : ControllerBase
{
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