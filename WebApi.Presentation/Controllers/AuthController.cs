using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;
using WebApi.Domain.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public readonly IAdOwnerRepository _adOwnerRepository;
    private readonly JwtService _jwtService;
    
    public AuthController(IAdOwnerRepository adOwnerRepository, JwtService jwtService)
    {
        _adOwnerRepository = adOwnerRepository;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(AdOwnerLoginModel model)
    {
        var response = _adOwnerRepository.Login(model);

        if (response == null)
        {
            return BadRequest("Unauthorized");
        }

        return Ok(new { token = response });
    }

    [HttpPost("register")]
    public IActionResult Register(AdOwnerRegisterModel model)
    {
        var isSuccessful = _adOwnerRepository.Register(model);

        if (!isSuccessful)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpGet("get-new-token/{token}")]
    public IActionResult GetNewToken(string token)
    {
        var newToken = _jwtService.GetNewToken(token);

        if (newToken == null)
        {
            return BadRequest();
        }

        return Ok(new { newToken });
    }
}