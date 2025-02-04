using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Requests;
using ToDo.Api.Requests.Auth;

namespace ToDo.Api.Controllers;

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