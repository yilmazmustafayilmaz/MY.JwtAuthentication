using JwtAuthentication.Business.Abstract;
using JwtAuthentication.Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authservice;

    public AuthController(IAuthService authservice)
    {
        _authservice = authservice;
    }

    [HttpPost("login")]
    public IActionResult Login(UserForLoginDto userForLoginDto)
    {
        var userToLogin = _authservice.Login(userForLoginDto);
        if (userToLogin == null)
            return BadRequest();

        var result = _authservice.CreateAccessToken(userToLogin);
        return Ok(result);
    }

    [HttpPost("register")]
    public IActionResult Register(UserForRegisterDto userForRegisterDto)
    {
        var userExists = _authservice.UserExists(userForRegisterDto.Email);
        if (userExists == false)
            return BadRequest();

        var registerResult = _authservice.Register(userForRegisterDto);
        var result = _authservice.CreateAccessToken(registerResult);
        return Ok(result);
    }
}
