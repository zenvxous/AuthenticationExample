using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserPlatform.API.Contracts.Users;
using UserPlatform.Core.Interfaces.Services;

namespace UserPlatform.API.Controllers;

[ApiController]
[Route("user")]
public class UsersController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUsersService _usersService;

    public UsersController(IHttpContextAccessor httpContextAccessor,IUsersService usersService)
    {
        _httpContextAccessor = httpContextAccessor;
        _usersService = usersService;
    }

    [HttpPost("register")]
    [Authorize]
    public async Task<ActionResult> Register([FromBody] RegisterUserRequest request)
    {
        await _usersService.RegisterUser(request.Name, request.Email, request.Password);
        
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginUserRequest request)
    {
        var context = _httpContextAccessor.HttpContext;
        
        var token = await _usersService.LoginUser(request.Email, request.Password, context);
         
        return Ok(token);
    }
    
}