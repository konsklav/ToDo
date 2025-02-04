using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Requests.Auth;

namespace ToDoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SignUpController : ControllerBase
{
    [HttpPost(Name = "Sign Up")]
    public async Task<IResult> Signup(SignUpRequest request)
    {
        throw new NotImplementedException();
    }
}